using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEDoubleHelper : PPEAbstractTypeHelper<double>
	{
		public PPEDoubleHelper(PPEHelper helper) : base(helper)
		{
		}

		#region double
		public override bool Set(string key, double value, bool isNeedCrypto = false)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return _helper.Set(key, bytes, new PPEDoubleType(), isNeedCrypto);
		}

		public override double Get(string key, double defaultValue = 0.0f)
		{
			double result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEDoubleType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEDoubleType(), item.type);
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

		#region double[]
		public override bool SetArray(string key, double[] array, bool isNeedCrypto = false)
		{
			byte[] bytes = new byte[array.Length * sizeof(double)];
			Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEDoubleArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<double> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override double[] GetArray(string key)
		{
			double[] result = new double[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEDoubleArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEDoubleType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<double> GetList(string key)
		{
			return new List<double>(GetArray(key));
		}

		public override double[] GetArray(string key, double defaultValue, int defaultSize = 2)
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

			var array = new double[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<double> GetList(string key, double defaultValue, int defaultSize = 2)
		{
			return new List<double>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override double Value(byte[] value)
		{
			return BitConverter.ToDouble(value, 0);
		}

		public override double[] Values(byte[] value)
		{
			var result = new double[value.Length / sizeof(double)];
			Buffer.BlockCopy(value, 0, result, 0, value.Length);

			return result;
		}
		#endregion
	}
}
