using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEBoolHelper : PPEAbstractTypeHelper<bool>
	{
		public PPEBoolHelper(PPEHelper helper) : base(helper)
		{
		}

		#region bool
		public override bool Set(string key, bool value, bool isNeedCrypto = false)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return _helper.Set(key, bytes, new PPEBoolType(), isNeedCrypto);
		}

		public override bool Get(string key, bool defaultValue = false)
		{
			bool result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEBoolType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEBoolType(), item.type);
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

		#region bool[]
		public override bool SetArray(string key, bool[] array, bool isNeedCrypto = false)
		{
			byte[] bytes = (from x in array select x ? (byte)0x1 : (byte)0x0).ToArray();
			return _helper.Set(key, bytes, new PPEBoolArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<bool> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override bool[] GetArray(string key)
		{
			bool[] result = new bool[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEBoolArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEBoolType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<bool> GetList(string key)
		{
			return new List<bool>(GetArray(key));
		}

		public override bool[] GetArray(string key, bool defaultValue, int defaultSize = 2)
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

			var boolArray = new bool[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				boolArray[i] = defaultValue;
			}

			return boolArray;
		}

		public override List<bool> GetList(string key, bool defaultValue, int defaultSize = 2)
		{
			return new List<bool>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override bool Value(byte[] value)
		{
			return BitConverter.ToBoolean(value, 0);
		}

		public override bool[] Values(byte[] value)
		{
			return (from x in value select x > 0).ToArray();
		}
		#endregion
	}
}