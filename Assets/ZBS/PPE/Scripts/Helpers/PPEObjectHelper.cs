using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ZBS.PPEHelpers
{
	public class PPEObjectHelper : PPEAbstractBaseTypeHelper<object> 
	{
		public PPEObjectHelper(PPEHelper helper) : base(helper)
		{
#if UNITY_IOS
			Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
#endif
		}

		public override bool Set(string key, object value, bool isNeedCrypto = false)
		{
			if (!value.GetType().IsSerializable)
			{
				Debug.LogWarning("Value is not serializable for key: " + key);

				return false;
			}

			using (MemoryStream stream = new MemoryStream())
			{
				new BinaryFormatter().Serialize(stream, value);
				var bytes = stream.ToArray();

				return _helper.Set(key, bytes, new PPEObjectType(), isNeedCrypto);
			}
		}

		public override object Get(string key, object defaultValue)
		{
			object result = defaultValue;
			var item = _helper.Get(key);

			if (item != null)
			{
				if (item.type.GetType() == typeof(PPEObjectType))
				{
					try
					{
						result = Value(item.value);
					}
					catch (Exception ex)
					{
						PPEHelper.DebugCorrupt(key, ex.ToString(), new PPEObjectType(), item.type);
					}
				}
				else
				{
					PPEHelper.DebugWrongType(key, item.type);
				}
			}

			return result;
		}

		public override object Value(byte[] value)
		{
			using (MemoryStream stream = new MemoryStream(value))
			{
				return new BinaryFormatter().Deserialize(stream);
			}
		}
	}
}
