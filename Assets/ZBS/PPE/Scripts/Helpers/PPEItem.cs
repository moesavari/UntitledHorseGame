using System;

namespace ZBS
{
	[Serializable]
	public class PPEItem
	{
		public PPEBaseType type;
		public string key;
		public byte[] value;
		public string stringValue;
		public bool isCrypted;

		public PPEItem(string key, byte[] value, PPEBaseType type, bool isCrypted = false)
		{
			this.key = key;
			this.value = value;
			this.type = type;
			this.isCrypted = isCrypted;
			stringValue = string.Empty;
		}

		public override string ToString()
		{
			return string.Format("[PPEItem] key:{0}, type:{1}, isCrypted:{2}", key, type.type, isCrypted);
		}
	}
}
