using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEQuaternionHelper : PPEAbstractTypeHelper<Quaternion>
	{
		public PPEQuaternionHelper(PPEHelper helper) : base(helper)
		{
		}

		byte _valuesCount = 4;

		#region Quaternion
		public override bool Set(string key, Quaternion value, bool isNeedCrypto = false)
		{
			var vectorValues = new float[] { value.x, value.y, value.z, value.w };
			byte[] bytes = new byte[vectorValues.Length * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEQuaternionType(), isNeedCrypto);
		}

		public override Quaternion Get(string key, Quaternion defaultValue)
		{
			Quaternion result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEQuaternionType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEQuaternionType(), item.type);
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

		#region Quaternion[]
		public override bool SetArray(string key, Quaternion[] array, bool isNeedCrypto = false)
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

			return _helper.Set(key, bytes, new PPEQuaternionArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<Quaternion> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override Quaternion[] GetArray(string key)
		{
			Quaternion[] result = new Quaternion[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEQuaternionArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEQuaternionArrayType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<Quaternion> GetList(string key)
		{
			return new List<Quaternion>(GetArray(key));
		}

		public override Quaternion[] GetArray(string key, Quaternion defaultValue, int defaultSize = 2)
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

			var array = new Quaternion[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<Quaternion> GetList(string key, Quaternion defaultValue, int defaultSize = 2)
		{
			return new List<Quaternion>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override Quaternion Value(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);

			return new Quaternion(arrayResult[0], arrayResult[1], arrayResult[2], arrayResult[3]);
		}

		public override Quaternion[] Values(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);
			int len = arrayResult.Length, index = 0;

			Quaternion[] result = new Quaternion[(len / _valuesCount)];

			for (int i = 0; i < len; i += _valuesCount)
			{
				result[index++] = new Quaternion(arrayResult[i], arrayResult[i + 1], arrayResult[i + 2], arrayResult[i + 3]);
			}

			return result;
		}
		#endregion
	}
}
