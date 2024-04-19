using ZBS.PPEHelpers;
using UnityEditor;
using UnityEngine;
using ZBS.PPEEditor;

namespace ZBS
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(PPECryptoManager))]
	public class PPECryptoManagerEditor : Editor
	{
		SerializedProperty _key;
		PPECryptoManager _cryptoManager;
		Texture2D _ppeLogoTexture;
		Texture2D _zbsLogoTexture;
		bool _didSetTextures;
		string _assetBasePath = "Assets/ZBS/PPE/Editor/GUI/";
		GUISkin _skin;
		string _editorKey;

		void OnEnable()
		{
			_editorKey = "PPECryptoManager:" + PlayerSettings.companyName + "." + PlayerSettings.productName;
			var key = EditorPrefs.GetString(_editorKey, "");

			_key = serializedObject.FindProperty("key");
			_key.stringValue = key;
			_cryptoManager = FindObjectOfType<PPECryptoManager>();

			SetTextures();
			SetGUISkin();
		}

		void SetTextures()
		{
			if (!_didSetTextures)
			{
				string texturesPath = "Textures/";

				_ppeLogoTexture = AssetDatabase.LoadAssetAtPath(_assetBasePath + texturesPath + "PPELogo.png", typeof(Texture2D)) as Texture2D;
				_zbsLogoTexture = AssetDatabase.LoadAssetAtPath(_assetBasePath + texturesPath + "ZBSLogo.png", typeof(Texture2D)) as Texture2D;

				_didSetTextures = true;
			}
		}

		void SetGUISkin()
		{
			string skinsPath = "Skins/";

			_skin = AssetDatabase.LoadAssetAtPath(_assetBasePath + skinsPath + "PPESkin.guiskin", typeof(GUISkin)) as GUISkin;
		}

		public override void OnInspectorGUI()
		{
			// play mode
			if (EditorApplication.isPlaying)
			{
				EditorGUILayout.HelpBox("\nLocked in Play mode\n", MessageType.Info, true);
				return;
			}

			// waiting prefab
			if (_cryptoManager == null)
			{
				EditorGUILayout.HelpBox("\nPlease drag PPECryptoManager prefab into Hierarchy window\n", MessageType.Info, true);
				return;
			}

			// inspector in project
			if (!Selection.activeTransform)
			{
				EditorGUILayout.HelpBox("\nPlease select PPECryptoManager in Hierarchy window\n", MessageType.Info, true);
				return;
			}

			// TODO: check only one crypto manager
			// multiselect
			if (Selection.objects.Length > 1)
			{
				EditorGUILayout.HelpBox("\nPlease use only one PPECryptoManager in Hierarchy window\n", MessageType.Info, true);
				return;
			}

			// warning: need key
			if (!IsValidKey())
			{
				EditorGUILayout.HelpBox("\nNeed to generate or set a Key\n", MessageType.Warning, true);
			}

			// editor mode
			serializedObject.Update();

			GUIStyle logoBoxStyle = _skin.GetStyle("LogoBox");

			// logos
			Rect r = EditorGUILayout.BeginHorizontal("Box");
			{
				GUI.Box(r, "", logoBoxStyle);
				GUILayout.Label(_ppeLogoTexture, GUILayout.MinWidth(24), GUILayout.MinHeight(12));
				GUILayout.FlexibleSpace();
				GUILayout.Label(_zbsLogoTexture, GUILayout.MinWidth(24), GUILayout.MinHeight(12));
			}
			EditorGUILayout.EndHorizontal();

			GUILayout.Space(5);

			EditorGUILayout.LabelField(new GUIContent("Key:", "Crypto key"));

			GUILayout.Space(2);

			_key.stringValue = EditorGUILayout.TextField(_key.stringValue);

			GUILayout.Space(5);

			EditorGUILayout.BeginHorizontal();
			{
				// generate
				if (GUILayout.Button("Generate new Key"))
				{
					if (EditorUtility.DisplayDialog("PPE - Generate Key", "Are you sure you want to generate a new key?", "Yes", "No"))
					{
						PPEItems.Instance.Reload(true);

						_key.stringValue = GenerateHash(32);
						serializedObject.ApplyModifiedProperties();
						EditorPrefs.SetString(_editorKey, _key.stringValue);

						// init crypto
						PPEHelper.Instance.InitCrypto(_key.stringValue);

						// update saved crypted values
						PPEItems.Instance.UpdateCrypto();
					}
				}

				if (GUILayout.Button(new GUIContent("Use", "Save current key")))
				{
					if (EditorUtility.DisplayDialog("PPE - Use Key", "Are you sure you want to use key \"" + _key.stringValue + "\"?", "Use", "Cancel"))
					{
						PPEItems.Instance.Reload(true);

						// save
						serializedObject.ApplyModifiedProperties();
						EditorPrefs.SetString(_editorKey, _key.stringValue);

						// init crypto
						PPEHelper.Instance.InitCrypto(_key.stringValue);

						// update saved crypted values
						PPEItems.Instance.UpdateCrypto();
					}
				}
			}
			EditorGUILayout.EndHorizontal();

			serializedObject.ApplyModifiedProperties();
		}

		string GenerateHash(int length = 32)
		{
			string result = "";
			string tempString = "1234567890qazwsxedcrfvtgbyhnujmikolpQAZWSXEDCRFVTGBYHNUJMIKOLP";
			int len = tempString.Length;

			for (int i = 0; i < length; i++)
			{
				result += tempString[Random.Range(0, len)];
			}

			return result;
		}

		bool IsValidKey()
		{
			return (_key.stringValue != string.Empty);
		}
	}
}