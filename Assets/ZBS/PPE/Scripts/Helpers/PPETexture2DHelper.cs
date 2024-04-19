using UnityEngine;
using System;

namespace ZBS.PPEHelpers
{
	public class PPETexture2DHelper : PPEAbstractBaseTypeHelper<Texture2D>
	{
		public PPETexture2DHelper(PPEHelper helper) : base(helper)
		{
		}

		byte _valuesCount = 4;

		#region Texture2D
		public override bool Set(string key, Texture2D value, bool isNeedCrypto = false)
		{
			byte[] rawBytes = value.GetRawTextureData();
			var values = new float[] { value.width, value.height, (int)value.format, value.mipmapCount };
			var valuesLen = _valuesCount * sizeof(float);
			byte[] bytes = new byte[valuesLen + rawBytes.Length];

			// copy params
			Buffer.BlockCopy(values, 0, bytes, 0, valuesLen);

			// copy rawTexture
			Buffer.BlockCopy(rawBytes, 0, bytes, valuesLen, rawBytes.Length);

			return _helper.Set(key, bytes, new PPETexture2DType(), isNeedCrypto);
		}

		public override Texture2D Get(string key, Texture2D defaultValue)
		{
			Texture2D result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPETexture2DType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPETexture2DType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}
		#endregion

		#region Values
		public override Texture2D Value(byte[] value)
		{
			var valuesLen = _valuesCount * sizeof(float);
			float[] arrayResult = new float[_valuesCount];
			byte[] rawBytes = new byte[value.Length - valuesLen];

			// copy params
			Buffer.BlockCopy(value, 0, arrayResult, 0, valuesLen);

			// copy rawTexture
			Buffer.BlockCopy(value, valuesLen, rawBytes, 0, rawBytes.Length);

			var texture = new Texture2D((int)arrayResult[0], (int)arrayResult[1], (TextureFormat)arrayResult[2], ((int)arrayResult[3]) > 1);
			texture.LoadRawTextureData(rawBytes);
			texture.Apply();
			return texture;
		}
		#endregion
	}
}
