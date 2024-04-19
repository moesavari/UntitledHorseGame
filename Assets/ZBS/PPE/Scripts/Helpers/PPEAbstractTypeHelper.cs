using System.Collections.Generic;

namespace ZBS.PPEHelpers
{
	public abstract class PPEAbstractBaseTypeHelper<T>
	{
		protected PPEHelper _helper;

		// constructor
		protected PPEAbstractBaseTypeHelper(PPEHelper helper)
		{
			_helper = helper;
		}

		// item
		public abstract bool Set(string key, T value, bool isNeedCrypto = false);
		public abstract T Get(string key, T defaultValue);

		// values
		public abstract T Value(byte[] value);
	}

	public abstract class PPEAbstractTypeHelper<T> : PPEAbstractBaseTypeHelper<T>
	{
		// constructor
		protected PPEAbstractTypeHelper(PPEHelper helper) : base(helper)
		{
		}

		// array of items
		public abstract bool SetArray(string key, T[] array, bool isNeedCrypto = false);
		public abstract bool SetList(string key, List<T> list, bool isNeedCrypto = false);
		public abstract T[] GetArray(string key);
		public abstract List<T> GetList(string key);
		public abstract T[] GetArray(string key, T defaultValue, int defaultSize = 2);
		public abstract List<T> GetList(string key, T defaultValue, int defaultSize = 2);

		// values
		public abstract T[] Values(byte[] value);
	}
}