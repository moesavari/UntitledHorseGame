using UnityEngine;

namespace ZBS
{
	// TODO: Set script order for this script
	public class PPECryptoManager : MonoBehaviour
	{
		public string key = "";

		void Awake()
		{
			PPE.InitCrypto(key);

			if (!Application.isEditor)
			{
				Destroy(this);
			}
		}
	}
}