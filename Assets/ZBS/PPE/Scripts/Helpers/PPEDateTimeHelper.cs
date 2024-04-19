using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEDateTimeHelper : PPEAbstractTypeHelper<DateTime>
	{
		public PPEDateTimeHelper(PPEHelper helper) : base(helper)
		{
		}

		#region DateTime
		public override bool Set(string key, DateTime value, bool isNeedCrypto = false)
		{
			var doubleValue = value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

			byte[] bytes = BitConverter.GetBytes(doubleValue);
			return PPEHelper.Instance.Set(key, bytes, new PPEDateTimeType(), isNeedCrypto);
		}

		public override DateTime Get(string key, DateTime defaultValue = default(DateTime))
		{
			DateTime result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEDateTimeType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEDateTimeType(), item.type);
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

		#region DateTime[]
		public override bool SetArray(string key, DateTime[] array, bool isNeedCrypto = false)
		{
			int len = array.Length;
			double[] doubleArray = new double[len];

			for (int i = 0; i < len; i++)
			{
				doubleArray[i] = array[i].ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			}

			byte[] bytes = new byte[len * sizeof(double)];
			Buffer.BlockCopy(doubleArray, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEDateTimeArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<DateTime> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override DateTime[] GetArray(string key)
		{
			DateTime[] result = new DateTime[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEDateTimeArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEDateTimeArrayType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<DateTime> GetList(string key)
		{
			return new List<DateTime>(GetArray(key));
		}

		public override DateTime[] GetArray(string key, DateTime defaultValue, int defaultSize = 2)
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

			var array = new DateTime[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<DateTime> GetList(string key, DateTime defaultValue, int defaultSize = 2)
		{
			return new List<DateTime>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override DateTime Value(byte[] value)
		{
			var resultDouble = BitConverter.ToDouble(value, 0);
			var result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

			return result.AddMilliseconds(resultDouble).ToLocalTime();
		}

		public override DateTime[] Values(byte[] value)
		{
			var resultDouble = new double[value.Length / sizeof(double)];
			Buffer.BlockCopy(value, 0, resultDouble, 0, value.Length);

			var len = resultDouble.Length;
			var result = new DateTime[len];

			for (int i = 0; i < len; i++)
			{
				result[i] = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(resultDouble[i]).ToLocalTime();
			}

			return result;
		}
		#endregion
	}
}
