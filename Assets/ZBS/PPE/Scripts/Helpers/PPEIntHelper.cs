using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEIntHelper : PPEAbstractTypeHelper<int>
	{
		public PPEIntHelper(PPEHelper helper) : base(helper)
		{
		}

		#region int
		public override bool Set(string key, int value, bool isNeedCrypto = false)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return _helper.Set(key, bytes, new PPEIntType(), isNeedCrypto);
		}

		public override int Get(string key, int defaultValue = 0)
		{
			int result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEIntType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEIntType(), item.type);
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

		#region int[]
		public override bool SetArray(string key, int[] array, bool isNeedCrypto = false)
		{
			byte[] bytes = new byte[array.Length * sizeof(int)];
			Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEIntArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<int> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override int[] GetArray(string key)
		{
			int[] result = new int[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEIntArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEIntArrayType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<int> GetList(string key)
		{
			return new List<int>(GetArray(key));
		}

		public override int[] GetArray(string key, int defaultValue, int defaultSize = 2)
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

			var array = new int[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<int> GetList(string key, int defaultValue, int defaultSize = 2)
		{
			return new List<int>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override int Value(byte[] value)
		{
			return BitConverter.ToInt32(value, 0);
		}

		public override int[] Values(byte[] value)
		{
			var result = new int[value.Length / sizeof(int)];
			Buffer.BlockCopy(value, 0, result, 0, value.Length);

			return result;
		}
		#endregion
	}
}