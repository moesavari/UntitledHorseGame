using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPELongHelper : PPEAbstractTypeHelper<long>
	{
		public PPELongHelper(PPEHelper helper) : base(helper)
		{
		}

		#region long
		public override bool Set(string key, long value, bool isNeedCrypto = false)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return _helper.Set(key, bytes, new PPELongType(), isNeedCrypto);
		}

		public override long Get(string key, long defaultValue = 0)
		{
			long result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPELongType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPELongType(), item.type);
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

		#region long[]
		public override bool SetArray(string key, long[] array, bool isNeedCrypto = false)
		{
			byte[] bytes = new byte[array.Length * sizeof(long)];
			Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPELongArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<long> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override long[] GetArray(string key)
		{
			long[] result = new long[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPELongArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPELongArrayType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<long> GetList(string key)
		{
			return new List<long>(GetArray(key));
		}

		public override long[] GetArray(string key, long defaultValue, int defaultSize = 2)
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

			var array = new long[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<long> GetList(string key, long defaultValue, int defaultSize = 2)
		{
			return new List<long>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override long Value(byte[] value)
		{
			return BitConverter.ToInt64(value, 0);
		}

		public override long[] Values(byte[] value)
		{
			var result = new long[value.Length / sizeof(long)];
			Buffer.BlockCopy(value, 0, result, 0, value.Length);

			return result;
		}
		#endregion
	}
}