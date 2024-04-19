using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEVector3Helper : PPEAbstractTypeHelper<Vector3>
	{
		public PPEVector3Helper(PPEHelper helper) : base(helper)
		{
		}

		byte _valuesCount = 3;

		#region Vector3
		public override bool Set(string key, Vector3 value, bool isNeedCrypto = false)
		{
			var vectorValues = new float[] { value.x, value.y, value.z };
			byte[] bytes = new byte[vectorValues.Length * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEVector3Type(), isNeedCrypto);
		}

		public override Vector3 Get(string key, Vector3 defaultValue)
		{
			Vector3 result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEVector3Type))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEVector3Type(), item.type);
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

		#region Vector3[]
		public override bool SetArray(string key, Vector3[] array, bool isNeedCrypto = false)
		{
			int len = array.Length, index = 0;
			var vectorValues = new float[len * _valuesCount];

			for (int i = 0; i < len; i++)
			{
				vectorValues[index++] = array[i].x;
				vectorValues[index++] = array[i].y;
				vectorValues[index++] = array[i].z;
			}

			byte[] bytes = new byte[len * _valuesCount * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEVector3ArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<Vector3> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override Vector3[] GetArray(string key)
		{
			Vector3[] result = new Vector3[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEVector3ArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEVector3Type(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<Vector3> GetList(string key)
		{
			return new List<Vector3>(GetArray(key));
		}

		public override Vector3[] GetArray(string key, Vector3 defaultValue, int defaultSize = 2)
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

			var array = new Vector3[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<Vector3> GetList(string key, Vector3 defaultValue, int defaultSize = 2)
		{
			return new List<Vector3>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override Vector3 Value(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);

			return new Vector3(arrayResult[0], arrayResult[1], arrayResult[2]);
		}

		public override Vector3[] Values(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);
			int len = arrayResult.Length, index = 0;

			Vector3[] result = new Vector3[(len / _valuesCount)];

			for (int i = 0; i < len; i += _valuesCount)
			{
				result[index++] = new Vector3(arrayResult[i], arrayResult[i + 1], arrayResult[i + 2]);
			}

			return result;
		}
		#endregion
	}
}