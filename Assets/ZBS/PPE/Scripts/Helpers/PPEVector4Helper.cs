using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEVector4Helper : PPEAbstractTypeHelper<Vector4>
	{
		public PPEVector4Helper(PPEHelper helper) : base(helper)
		{
		}

		byte _valuesCount = 4;

		#region Vector4
		public override bool Set(string key, Vector4 value, bool isNeedCrypto = false)
		{
			var vectorValues = new float[] { value.x, value.y, value.z, value.w };
			byte[] bytes = new byte[vectorValues.Length * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEVector4Type(), isNeedCrypto);
		}

		public override Vector4 Get(string key, Vector4 defaultValue)
		{
			Vector4 result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEVector4Type))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEVector4Type(), item.type);
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

		#region Vector4[]
		public override bool SetArray(string key, Vector4[] array, bool isNeedCrypto = false)
		{
			int len = array.Length, index = 0;
			var vectorValues = new float[len * _valuesCount];

			for (int i = 0; i < len; i++)
			{
				vectorValues[index++] = array[i].x;
				vectorValues[index++] = array[i].y;
				vectorValues[index++] = array[i].z;
				vectorValues[index++] = array[i].w;
			}

			byte[] bytes = new byte[len * _valuesCount * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEVector4ArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<Vector4> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override Vector4[] GetArray(string key)
		{
			Vector4[] result = new Vector4[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEVector4ArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEVector4Type(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<Vector4> GetList(string key)
		{
			return new List<Vector4>(GetArray(key));
		}

		public override Vector4[] GetArray(string key, Vector4 defaultValue, int defaultSize = 2)
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

			var array = new Vector4[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<Vector4> GetList(string key, Vector4 defaultValue, int defaultSize = 2)
		{
			return new List<Vector4>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override Vector4 Value(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);

			return new Vector4(arrayResult[0], arrayResult[1], arrayResult[2], arrayResult[3]);
		}

		public override Vector4[] Values(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);
			int len = arrayResult.Length, index = 0;

			Vector4[] result = new Vector4[(len / _valuesCount)];

			for (int i = 0; i < len; i += _valuesCount)
			{
				result[index++] = new Vector4(arrayResult[i], arrayResult[i + 1], arrayResult[i + 2], arrayResult[i + 3]);
			}

			return result;
		}
		#endregion
	}
}