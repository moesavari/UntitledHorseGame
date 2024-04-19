using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;
using ZBS.PPEHelpers;

namespace ZBS.PPEEditor
{
	public class PPEItems
	{
		#region Singleton
		static readonly PPEItems instance = new PPEItems();

		static PPEItems() { }
		PPEItems()
		{
			_items = new Dictionary<string, PPEItem>();
		}

		public static PPEItems Instance
		{
			get { return instance; }
		}
		#endregion

		Dictionary<string, PPEItem> _items;
		public Dictionary<string, PPEItem> items
		{
			get { return _items; }
		}

		float _reloadPeriod = 2.5f;
		public float reloadPeriod
		{
			get
			{
				return _reloadPeriod;
			}
			set
			{
				_reloadPeriod = Mathf.Clamp(value, 0.1f, 100.0f);
			}
		}

		float _nextReloadTime;

		void ReloadData()
		{
			// clean items
			_items.Clear();

			string[] keys = new string[0];
			object[] values = new object[0];
			int itemsCount = 0;

			if (Application.platform == RuntimePlatform.OSXEditor)
			{
				var file = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/Library/Preferences/" + "unity." + PlayerSettings.companyName + "." + PlayerSettings.productName + ".plist");

				if (file.Exists)
				{
					var pList = PlistCS.Plist.readPlist(file.FullName) as Dictionary<string, object>;

					if (pList != null)
					{
						itemsCount = pList.Count;
						keys = new string[itemsCount];
						values = new object[itemsCount];

						// copy keys/values
						pList.Keys.CopyTo(keys, 0);
						pList.Values.CopyTo(values, 0);

						// clean memory
						pList = null;
					}
				}
			}
			else if (Application.platform == RuntimePlatform.WindowsEditor)
			{
				var registryKey = Registry.CurrentUser.CreateSubKey("Software\\" + PlayerSettings.companyName + "\\" + PlayerSettings.productName);

				if (registryKey != null)
				{
					keys = registryKey.GetValueNames();
					itemsCount = keys.Length;
					values = new object[itemsCount];

					int index = 0;

					foreach (string currentKey in keys)
					{
						values[index] = registryKey.GetValue(currentKey);
						index++;
					}

					// clean memory
					registryKey = null;
				}
			}
			else
			{
				Debug.LogWarning("Unsupported platform");
				return;
			}

			// each data if exist
			PPEHelper helper = PPEHelper.Instance;

			for (int i = 0; i < itemsCount; i++)
			{
				string key = keys[i];

				if (key.StartsWith(PPEHelper.prefix, StringComparison.Ordinal))
				{
					string humanKey = helper.ConvertToHumanKey(key);
					PPEItem item = helper.Get(humanKey, true);

					if (item != null)
					{
						_items.Add(key, item);
					}	
				}
			}
		}

		public bool Reload(bool force = false)
		{
			if (force || EditorApplication.timeSinceStartup > _nextReloadTime)
			{
				ReloadData();

				_nextReloadTime = (float)(EditorApplication.timeSinceStartup + _reloadPeriod);

				return true;
			}

			return false;
		}

		public void UpdateCrypto()
		{
			foreach (var keyValue in _items)
			{
				PPEItem item = keyValue.Value;

				if (item.isCrypted)
				{
					PPEHelper.Instance.Set(item.key, item.value, item.type, true);
				}
			}
		}
	}
}
