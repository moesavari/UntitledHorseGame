using UnityEngine;
using System;

namespace ZBS.PPEHelpers
{
	public sealed class PPEHelper
	{
		static readonly PPEHelper instance = new PPEHelper();
		public static string prefix = "PPE|";
		public static string cryptoTag = "c";

		PPECryptoHelper _cryptoHelper;
		PPEBoolHelper _boolHelper;
		PPEIntHelper _intHelper;
		PPELongHelper _longHelper;
		PPEFloatHelper _floatHelper;
		PPEDoubleHelper _doubleHelper;
		PPEVector2Helper _vector2Helper;
		PPEVector3Helper _vector3Helper;
		PPEVector4Helper _vector4Helper;
		PPEQuaternionHelper _quaternionHelper;
		PPERectHelper _rectHelper;
		PPEColorHelper _colorHelper;
		PPEDateTimeHelper _dateTimeHelper;
		PPEStringHelper _stringHelper;
		PPETexture2DHelper _texture2DHelper;
		PPEObjectHelper _objectHelper;

		static PPEHelper()
		{
		}

		public static PPEHelper Instance
		{
			get { return instance; }
		}

		PPEHelper()
		{
			_boolHelper = new PPEBoolHelper(this);
			_intHelper = new PPEIntHelper(this);
			_longHelper = new PPELongHelper(this);
			_floatHelper = new PPEFloatHelper(this);
			_doubleHelper = new PPEDoubleHelper(this);
			_vector2Helper = new PPEVector2Helper(this);
			_vector3Helper = new PPEVector3Helper(this);
			_vector4Helper = new PPEVector4Helper(this);
			_quaternionHelper = new PPEQuaternionHelper(this);
			_rectHelper = new PPERectHelper(this);
			_colorHelper = new PPEColorHelper(this);
			_dateTimeHelper = new PPEDateTimeHelper(this);
			_stringHelper = new PPEStringHelper(this);
			_texture2DHelper = new PPETexture2DHelper(this);
			_objectHelper = new PPEObjectHelper(this);
		}

		#region Getters
		public bool DidInitCrypto()
		{
			return (_cryptoHelper != null);
		}

		public PPEBoolHelper boolHelper
		{
			get { return _boolHelper; }
		}

		public PPEIntHelper intHelper
		{
			get { return _intHelper; }
		}

		public PPELongHelper longHelper
		{
			get { return _longHelper; }
		}

		public PPEFloatHelper floatHelper
		{
			get { return _floatHelper; }
		}

		public PPEDoubleHelper doubleHelper
		{
			get { return _doubleHelper; }
		}

		public PPEVector2Helper vector2Helper
		{
			get { return _vector2Helper; }
		}

		public PPEVector3Helper vector3Helper
		{
			get { return _vector3Helper; }
		}

		public PPEVector4Helper vector4Helper
		{
			get { return _vector4Helper; }
		}

		public PPEQuaternionHelper quaternionHelper
		{
			get { return _quaternionHelper; }
		}

		public PPERectHelper rectHelper
		{
			get { return _rectHelper; }
		}

		public PPEColorHelper colorHelper
		{
			get { return _colorHelper; }
		}

		public PPEDateTimeHelper dateTimeHelper
		{
			get { return _dateTimeHelper; }
		}

		public PPEStringHelper stringHelper
		{
			get { return _stringHelper; }
		}

		public PPETexture2DHelper texture2DHelper
		{
			get { return _texture2DHelper; }
		}

		public PPEObjectHelper objectHelper
		{
			get { return _objectHelper; }
		}
		#endregion

		public bool HasKey(string key)
		{
			return PlayerPrefs.HasKey(ConvertToPPEKey(key));
		}

		public void Save()
		{
			PlayerPrefs.Save();
		}

		public void DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(ConvertToPPEKey(key));
		}

		public void DeleteAll()
		{
			// TODO: remove all only PPE keys
			PlayerPrefs.DeleteAll();
		}

		#region Accessors for items
		public bool Set(string key, byte[] value, PPEBaseType type, bool isNeedCrypto = false)
		{
			try
			{
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(value);
				}

				string valueString = Convert.ToBase64String(value);
				string cryptoSuffix = "";

				if (isNeedCrypto)
				{
					if (!DidInitCrypto())
					{
						throw new Exception("Please to check PPECryptoManager! Firstly need to initialize it!");
					}

					valueString = _cryptoHelper.Encrypt(valueString);
					cryptoSuffix = ":" + cryptoTag;
				}

				string saveValue = type.shortType + cryptoSuffix + "|" + valueString;
				string saveKey = ConvertToPPEKey(key);

				PlayerPrefs.SetString(saveKey, saveValue);

				return true;
			}
			catch (Exception ex)
			{
				Debug.LogError(ex);

				return false;
			}
		}

		public PPEItem Get(string key, bool isNeedStringValue = false)
		{
			string savedKey = ConvertToPPEKey(key);

			if (PlayerPrefs.HasKey(savedKey))
			{
				string savedString = PlayerPrefs.GetString(savedKey, null);

				if (savedString != null)
				{
					try
					{
						// 0 - settings, 1 - value
						string[] settingsAndValue = savedString.Split('|');

						// 0 - type, 1 - crypto
						string[] settings = settingsAndValue[0].Split(':');

						PPEBaseType currentType = PPETypeUtil.GetType(settings[0]);

						if (currentType.GetType() != typeof(PPEBaseType))
						{
							string stringValue = settingsAndValue[1];

							bool isCrypted = (settings.Length > 1 && settings[1] == cryptoTag);

							// check crypto & decrypt
							if (isCrypted)
							{
								if (!DidInitCrypto())
								{
									throw new Exception("Please to check PPECryptoManager! Firstly need to initialize it!");
								}

								stringValue = _cryptoHelper.Decrypt(stringValue);
								isCrypted = true;
							}

							// convert to bytes
							byte[] bytes = Convert.FromBase64String(stringValue);

							// reverse is needed
							if (BitConverter.IsLittleEndian)
							{
								Array.Reverse(bytes);
							}

							// create new item
							var item = new PPEItem(key, bytes, currentType, isCrypted);

							// add string value
							if (isNeedStringValue)
							{
								UpdateStringValue(ref item);
							}

							return item;
						}
					}
					catch (Exception ex)
					{
						Debug.LogError(ex);
					}
				}
			}

			return null;
		}

		void UpdateStringValue(ref PPEItem item)
		{
			if (item != null)
			{
				string delimiter = ", ";
				string stringValue = string.Empty;

				// bool
				if (item.type.GetType() == typeof(PPEBoolType))
				{
					stringValue = _boolHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEBoolArrayType))
				{
					bool[] array = _boolHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// int
				else if (item.type.GetType() == typeof(PPEIntType))
				{
					stringValue = _intHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEIntArrayType))
				{
					int[] array = _intHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// long
				else if (item.type.GetType() == typeof(PPELongType))
				{
					stringValue = _longHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPELongArrayType))
				{
					long[] array = _longHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// float
				else if (item.type.GetType() == typeof(PPEFloatType))
				{
					stringValue = _floatHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEFloatArrayType))
				{
					float[] array = _floatHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// double
				else if (item.type.GetType() == typeof(PPEDoubleType))
				{
					stringValue = _doubleHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEDoubleArrayType))
				{
					double[] array = _doubleHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// Vector2
				else if (item.type.GetType() == typeof(PPEVector2Type))
				{
					stringValue = _vector2Helper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEVector2ArrayType))
				{
					Vector2[] array = _vector2Helper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// Vector3
				else if (item.type.GetType() == typeof(PPEVector3Type))
				{
					stringValue = _vector3Helper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEVector3ArrayType))
				{
					Vector3[] array = _vector3Helper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// Vector4
				else if (item.type.GetType() == typeof(PPEVector4Type))
				{
					stringValue = _vector4Helper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEVector4ArrayType))
				{
					Vector4[] array = _vector4Helper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// Quanterion
				else if (item.type.GetType() == typeof(PPEQuaternionType))
				{
					stringValue = _quaternionHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEQuaternionArrayType))
				{
					Quaternion[] array = _quaternionHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// Rect
				else if (item.type.GetType() == typeof(PPERectType))
				{
					stringValue = _rectHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPERectArrayType))
				{
					Rect[] array = _rectHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// Color
				else if (item.type.GetType() == typeof(PPEColorType))
				{
					stringValue = _colorHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEColorArrayType))
				{
					Color[] array = _colorHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// DateTime
				else if (item.type.GetType() == typeof(PPEDateTimeType))
				{
					stringValue = _dateTimeHelper.Value(item.value).ToString();
				}
				else if (item.type.GetType() == typeof(PPEDateTimeArrayType))
				{
					DateTime[] array = _dateTimeHelper.Values(item.value);
					stringValue = string.Join(delimiter, Array.ConvertAll(array, x => x.ToString()));
				}
				// String
				else if (item.type.GetType() == typeof(PPEStringType))
				{
					stringValue = _stringHelper.Value(item.value);
				}
				else if (item.type.GetType() == typeof(PPEStringArrayType))
				{
					string[] array = _stringHelper.Values(item.value);
					stringValue = string.Join(delimiter, array);
				}
				// Texture2D
				else if (item.type.GetType() == typeof(PPETexture2DType))
				{
					stringValue = "[Texture2D ...]";
				}
				// Object
				else if (item.type.GetType() == typeof(PPEObjectType))
				{
					stringValue = "[Object ...]";
				}

				// set out property
				item.stringValue = stringValue;
			}
		}
		#endregion

		#region Key
		public string ConvertToHumanKey(string key)
		{
			if (key.StartsWith(prefix, StringComparison.Ordinal))
			{
				return key.Substring(prefix.Length);
			}

			return key;
		}

		public string ConvertToPPEKey(string key)
		{
			if (key.StartsWith(prefix, StringComparison.Ordinal))
			{
				return key;
			}

			return prefix + key;
		}
		#endregion

		#region Crypto
		public void InitCrypto(string key)
		{
			if (key != string.Empty)
			{
				try
				{
					_cryptoHelper = new PPECryptoHelper(key);
				}
				catch (Exception ex)
				{
					Debug.LogError(ex);
				}
			}
		}

		public void DestroyCrypto()
		{
			_cryptoHelper = null;
		}
		#endregion

		#region Debug
		public static void DebugCorrupt(string key, string message, PPEBaseType expectedType, PPEBaseType actualType)
		{
			var corruptMessage = "Corrupt PlayerPrefs for key: " + key + " expected: " +
				expectedType.type + ", actual: " + actualType.type + "\n" + message;
			Debug.LogError(corruptMessage);
		}

		public static void DebugWrongType(string key, PPEBaseType type)
		{
			Debug.LogError("Wrong type " + type.type + "for key: " + key);
		}
		#endregion
	}
}
