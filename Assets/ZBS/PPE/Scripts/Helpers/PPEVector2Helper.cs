using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEVector2Helper : PPEAbstractTypeHelper<Vector2>
	{
		public PPEVector2Helper(PPEHelper helper) : base(helper)
		{
		}

		byte _valuesCount = 2;

		#region Vector2
		public override bool Set(string key, Vector2 value, bool isNeedCrypto = false)
		{
			var vectorValues = new float[] { value.x, value.y };
			byte[] bytes = new byte[vectorValues.Length * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return PPEHelper.Instance.Set(key, bytes, new PPEVector2Type(), isNeedCrypto);
		}

		public override Vector2 Get(string key, Vector2 defaultValue)
		{
			Vector2 result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEVector2Type))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEVector2Type(), item.type);
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

		#region Vector2[]
		public override bool SetArray(string key, Vector2[] array, bool isNeedCrypto = false)
		{
			int len = array.Length, index = 0;
			var vectorValues = new float[len * _valuesCount];

			for (int i = 0; i < len; i++)
			{
				vectorValues[index++] = array[i].x;
				vectorValues[index++] = array[i].y;
			}

			byte[] bytes = new byte[len * _valuesCount * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return PPEHelper.Instance.Set(key, bytes, new PPEVector2ArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<Vector2> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override Vector2[] GetArray(string key)
		{
			Vector2[] result = new Vector2[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEVector2ArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEVector2Type(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<Vector2> GetList(string key)
		{
			return new List<Vector2>(GetArray(key));
		}

		public override Vector2[] GetArray(string key, Vector2 defaultValue, int defaultSize = 2)
		{
			if (PPEHelper.Instance.HasKey(key))
			{
				return GetArray(key);
			}

			if (defaultSize < 0)
			{
				Debug.LogError("defaultSize cannot be less 0");

				defaultSize = 0;
			}

			var array = new Vector2[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<Vector2> GetList(string key, Vector2 defaultValue, int defaultSize = 2)
		{
			return new List<Vector2>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override Vector2 Value(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);

			return new Vector2(arrayResult[0], arrayResult[1]);
		}

		public override Vector2[] Values(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);
			int len = arrayResult.Length, index = 0;

			Vector2[] result = new Vector2[(len / _valuesCount)];

			for (int i = 0; i < len; i += _valuesCount)
			{
				result[index++] = new Vector2(arrayResult[i], arrayResult[i + 1]);
			}

			return result;
		}
		#endregion
	}
}