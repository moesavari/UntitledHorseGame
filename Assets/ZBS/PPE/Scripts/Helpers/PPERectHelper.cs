using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPERectHelper : PPEAbstractTypeHelper<Rect>
	{
		public PPERectHelper(PPEHelper helper) : base(helper)
		{
		}

		byte _valuesCount = 4;

		#region Rect
		public override bool Set(string key, Rect value, bool isNeedCrypto = false)
		{
			var vectorValues = new float[] { value.x, value.y, value.width, value.height };
			byte[] bytes = new byte[vectorValues.Length * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPERectType(), isNeedCrypto);
		}

		public override Rect Get(string key, Rect defaultValue)
		{
			Rect result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPERectType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPERectType(), item.type);
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

		#region Rect[]
		public override bool SetArray(string key, Rect[] array, bool isNeedCrypto = false)
		{
			int len = array.Length, index = 0;
			var vectorValues = new float[len * _valuesCount];

			for (int i = 0; i < len; i++)
			{
				vectorValues[index++] = array[i].x;
				vectorValues[index++] = array[i].y;
				vectorValues[index++] = array[i].width;
				vectorValues[index++] = array[i].height;
			}

			byte[] bytes = new byte[len * _valuesCount * sizeof(float)];
			Buffer.BlockCopy(vectorValues, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPERectArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<Rect> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override Rect[] GetArray(string key)
		{
			Rect[] result = new Rect[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPERectArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPERectArrayType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<Rect> GetList(string key)
		{
			return new List<Rect>(GetArray(key));
		}

		public override Rect[] GetArray(string key, Rect defaultValue, int defaultSize = 2)
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

			var array = new Rect[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<Rect> GetList(string key, Rect defaultValue, int defaultSize = 2)
		{
			return new List<Rect>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override Rect Value(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);

			return new Rect(arrayResult[0], arrayResult[1], arrayResult[2], arrayResult[3]);
		}

		public override Rect[] Values(byte[] value)
		{
			float[] arrayResult = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, arrayResult, 0, value.Length);
			int len = arrayResult.Length, index = 0;

			Rect[] result = new Rect[(len / _valuesCount)];

			for (int i = 0; i < len; i += _valuesCount)
			{
				result[index++] = new Rect(arrayResult[i], arrayResult[i + 1], arrayResult[i + 2], arrayResult[i + 3]);
			}

			return result;
		}
		#endregion
	}
}
