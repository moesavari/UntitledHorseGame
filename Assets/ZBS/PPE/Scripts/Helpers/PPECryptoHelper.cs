using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ZBS.PPEHelpers
{
	public class PPECryptoHelper
	{
		const int keySize = 256;
		const int derivationIterationsCount = 2000;
		string _key = string.Empty;

		public PPECryptoHelper(string key)
		{
			_key = key;
		}

		public string Encrypt(string text)
		{
			var saltStringBytes = GenerateRandom256Bits();
			var ivStringBytes = GenerateRandom256Bits();
			var textBytes = Encoding.UTF8.GetBytes(text);
			var password = new Rfc2898DeriveBytes(_key, saltStringBytes, derivationIterationsCount);
			var keyBytes = password.GetBytes(keySize / 8);

			using (var rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.BlockSize = 256;
				rijndaelManaged.Mode = CipherMode.CBC;
				rijndaelManaged.Padding = PaddingMode.PKCS7;

				using (var encryptor = rijndaelManaged.CreateEncryptor(keyBytes, ivStringBytes))
				{
					using (var memoryStream = new MemoryStream())
					{
						using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
						{
							cryptoStream.Write(textBytes, 0, textBytes.Length);
							cryptoStream.FlushFinalBlock();

							var cipherTextBytes = saltStringBytes;
							cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
							cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
							memoryStream.Close();
							cryptoStream.Close();

							return Convert.ToBase64String(cipherTextBytes);
						}
					}
				}
			}

		}

		public string Decrypt(string encryptedText)
		{
			var encryptedTextBytesWithSaltAndIV = Convert.FromBase64String(encryptedText);
			var saltStringBytes = encryptedTextBytesWithSaltAndIV.Take(keySize / 8).ToArray();
			var ivStringBytes = encryptedTextBytesWithSaltAndIV.Skip(keySize / 8).Take(keySize / 8).ToArray();
			var encryptedTextBytes = encryptedTextBytesWithSaltAndIV.Skip((keySize / 8) * 2).Take(encryptedTextBytesWithSaltAndIV.Length - ((keySize / 8) * 2)).ToArray();
			var password = new Rfc2898DeriveBytes(_key, saltStringBytes, derivationIterationsCount);
			var keyBytes = password.GetBytes(keySize / 8);

			using (var rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.BlockSize = 256;
				rijndaelManaged.Mode = CipherMode.CBC;
				rijndaelManaged.Padding = PaddingMode.PKCS7;

				using (var decryptor = rijndaelManaged.CreateDecryptor(keyBytes, ivStringBytes))
				{
					using (var memoryStream = new MemoryStream(encryptedTextBytes))
					{
						using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
						{
							var textBytes = new byte[encryptedTextBytes.Length];
							var decryptedByteCount = cryptoStream.Read(textBytes, 0, textBytes.Length);
							memoryStream.Close();
							cryptoStream.Close();

							return Encoding.UTF8.GetString(textBytes, 0, decryptedByteCount);
						}
					}
				}
			}
		}

		byte[] GenerateRandom256Bits()
		{
			var bytes = new byte[32];
			var rngCSP = new RNGCryptoServiceProvider();
			rngCSP.GetBytes(bytes);

			return bytes;
		}
	}
}