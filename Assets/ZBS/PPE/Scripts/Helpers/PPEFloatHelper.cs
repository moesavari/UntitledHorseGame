using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEFloatHelper : PPEAbstractTypeHelper<float>
	{
		public PPEFloatHelper(PPEHelper helper) : base(helper)
		{
		}

		#region float
		public override bool Set(string key, float value, bool isNeedCrypto = false)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return PPEHelper.Instance.Set(key, bytes, new PPEFloatType(), isNeedCrypto);
		}

		public override float Get(string key, float defaultValue = 0.0f)
		{
			float result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEFloatType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEFloatType(), item.type);
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

		#region float[]
		public override bool SetArray(string key, float[] array, bool isNeedCrypto = false)
		{
			byte[] bytes = new byte[array.Length * sizeof(float)];
			Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);

			return _helper.Set(key, bytes, new PPEFloatArrayType(), isNeedCrypto);
		}

		public override bool SetList(string key, List<float> list, bool isNeedCrypto = false)
		{
			return SetArray(key, list.ToArray(), isNeedCrypto);
		}

		public override float[] GetArray(string key)
		{
			float[] result = new float[0];
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEFloatArrayType))
				{
					try
					{
						result = Values(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEFloatArrayType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override List<float> GetList(string key)
		{
			return new List<float>(GetArray(key));
		}

		public override float[] GetArray(string key, float defaultValue, int defaultSize = 2)
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

			var array = new float[defaultSize];

			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}

			return array;
		}

		public override List<float> GetList(string key, float defaultValue, int defaultSize = 2)
		{
			return new List<float>(GetArray(key, defaultValue, defaultSize));
		}
		#endregion

		#region Values
		public override float Value(byte[] value)
		{
			return BitConverter.ToSingle(value, 0);
		}

		public override float[] Values(byte[] value)
		{
			var result = new float[value.Length / sizeof(float)];
			Buffer.BlockCopy(value, 0, result, 0, value.Length);

			return result;
		}
		#endregion
	}
}
