using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEStringHelper : PPEAbstractTypeHelper<string>
	{
		public PPEStringHelper(PPEHelper helper) : base(helper)
		{
		}

		#region string
		public override bool Set(string key, string value, bool isNeedCrypto = false)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			return _helper.Set(key, bytes, new PPEStringType(), isNeedCrypto);
		}

		public override string Get(string key, string defaultValue = default(string))
		{
			string result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEStringType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEStringType(), item.type);
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

		#region string[]
		public override bool SetArray(string key, string[] array, bool isNeedCrypto = false)
		{
			var strings = string.Join("|", Array.ConvertAll(array, x => Convert.ToBase64String((Encoding.UTF8.GetBytes(x)))));
			byte[] bytes = Encoding.UTF8.GetBytes(strings);
			return _helper.Set(key, bytes, new PPEStringArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<string> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override string[] GetArray(string key)
		{
			string[] result = new string[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEStringArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEStringType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<string> GetList(string key)
		{
			return new List<string>(GetArray(key));
		}

		public override string[] GetArray(string key, string defaultValue, int defaultSize = 2)
		{
			if (_helper.HasKey(key))
			{
				return GetArray(key);
			}

			if (defaultSize < 0)
			{
				Debug.LogError("defaultSize cannot be less 0");

				defaultSize = 0;
			}

			var stringArray = new string[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				stringArray[i] = defaultValue;
			}

			return stringArray;
		}

		public override List<string> GetList(string key, string defaultValue, int defaultSize = 2)
		{
			return new List<string>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override string Value(byte[] value)
		{
			return Encoding.UTF8.GetString(value);
		}

		public override string[] Values(byte[] value)
		{
			var base64EncodedString = Encoding.UTF8.GetString(value);
			var array = base64EncodedString.Split(new char[] { '|' });

			return Array.ConvertAll(array, x => Encoding.UTF8.GetString(Convert.FromBase64String(x)));
		}
		#endregion
	}
}
