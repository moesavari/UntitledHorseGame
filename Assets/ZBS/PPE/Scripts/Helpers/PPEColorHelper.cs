using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEColorHelper : PPEAbstractTypeHelper<Color>
	{
		public PPEColorHelper(PPEHelper helper) : base(helper)
		{
		}

		byte _valuesCount = 4;

		#region Color
		public override bool Set(string key, Color value, bool isNeedCrypto = false)
		{
			var vectorValues = new float[] { value.r, value.g, value.b, value.a };
			byte[] bytes = new byte[vectorValues.Length * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEColorType(), isNeedCrypto);
		}

		public override Color Get(string key, Color defaultValue)
		{
			Color result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEColorType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEColorType(), item.type);
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

		#region Color[]
		public override bool SetArray(string key, Color[] array, bool isNeedCrypto = false)
		{
			int len = array.Length, index = 0;
			var vectorValues = new float[len * _valuesCount];

			for (int i = 0; i < len; i++)
			{
				vectorValues[index++] = array[i].r;
				vectorValues[index++] = array[i].g;
				vectorValues[index++] = array[i].b;
				vectorValues[index++] = array[i].a;
			}

			byte[] bytes = new byte[len * _valuesCount * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEColorArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<Color> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override Color[] GetArray(string key)
		{
			Color[] result = new Color[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEColorArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEColorArrayType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<Color> GetList(string key)
		{
			return new List<Color>(GetArray(key));
		}

		public override Color[] GetArray(string key, Color defaultValue, int defaultSize = 2)
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

			var array = new Color[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<Color> GetList(string key, Color defaultValue, int defaultSize = 2)
		{
			return new List<Color>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override Color Value(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);

			return new Color(arrayResult[0], arrayResult[1], arrayResult[2], arrayResult[3]);
		}

		public override Color[] Values(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);
			int len = arrayResult.Length, index = 0;

			Color[] result = new Color[(len / _valuesCount)];

			for (int i = 0; i < len; i += _valuesCount)
			{
				result[index++] = new Color(arrayResult[i], arrayResult[i + 1], arrayResult[i + 2], arrayResult[i + 3]);
			}

			return result;
		}
		#endregion
	}
}
