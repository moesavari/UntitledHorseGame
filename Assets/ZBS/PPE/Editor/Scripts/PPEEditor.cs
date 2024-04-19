using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using ZBS.PPEHelpers;

namespace ZBS.PPEEditor
{
	public class PPEEditor : EditorWindow
	{
		Vector2 _scrollPosition;
		//Texture2D _editButtonTexture;
		//Texture2D _saveButtonTexture;
		Texture2D _deleteButtonTexture;
		Texture2D _ppeLogoTexture;
		Texture2D _zbsLogoTexture;
		PPECryptoManager _cryptoManager;
		bool _didSetTextures;

		// settings
		bool _isNeedShowSettings;
		bool _isNeedShowItems;

		// assets
		string _assetBasePath = "Assets/ZBS/PPE/Editor/GUI/";
		GUISkin _skin;

		[MenuItem("Window/PPE [Player Prefs Extesion]")]
		static void Init()
		{
			var window = (PPEEditor)GetWindow(typeof(PPEEditor), false, "PPE Editor");
			window.Show();
		}

		void SetTextures()
		{
			if (!_didSetTextures)
			{
				string texturesPath = "Textures/";

				//_editButtonTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(_assetBasePath + texturesPath + "EditIcon.png");
				//_saveButtonTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(_assetBasePath + texturesPath + "SaveIcon.png");
				_deleteButtonTexture = AssetDatabase.LoadAssetAtPath(_assetBasePath + texturesPath + "DeleteIcon.png", typeof(Texture2D)) as Texture2D;
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

		void OnEnable()
		{
			SetTextures();
			SetGUISkin();

			EditorApplication.RepaintProjectWindow();
		}

		void OnInspectorUpdate()
		{
			if (_cryptoManager == null)
			{
				_cryptoManager = FindObjectOfType<PPECryptoManager>();

				//PPEHelper.Instance.InitCrypto(_cryptoManager.key);
			}

			if (_cryptoManager != null)
			{
				if (PPEHelper.Instance.DidInitCrypto())
				{
					if (PPEItems.Instance.Reload())
					{
						Repaint();
					}
				}
				else
				{
					PPEHelper.Instance.InitCrypto(_cryptoManager.key);
				}
			}
		}

		void OnGUI()
		{
			if (_cryptoManager == null)
			{
				EditorGUILayout.HelpBox("\nPPECryptoManager prefab not found!\nDrag PPECryptoManager prefab into Hierarchy Window\n", MessageType.Warning, true);

				return;
			}

			if (!PPEHelper.Instance.DidInitCrypto())
			{
				EditorGUILayout.HelpBox("\nNeed to generate or set Key and IV for PPECryptoManager\n", MessageType.Warning, true);

				return;
			}

			// styles
			GUIStyle labelCounterStyle = _skin.GetStyle("LabelCounter");
			GUIStyle labelTypeStyle = _skin.GetStyle("LabelType");
			GUIStyle labelKeyStyle = _skin.GetStyle("LabelKey");
			GUIStyle labelValueStyle = _skin.GetStyle("LabelValue");
			GUIStyle labelIndicatorStyle = _skin.GetStyle("LabelIndicator");
			GUIStyle itemsSeparatorStyle = _skin.GetStyle("ItemsSeparator");
			GUIStyle itemsDeleteButtonStyle = _skin.GetStyle("ItemsDeleteButton");
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

			GUILayout.Space(2);

			// title
			_isNeedShowSettings = EditorGUILayout.Foldout(_isNeedShowSettings, "Settings");
			if (_isNeedShowSettings)
			{
				EditorGUILayout.BeginHorizontal();
				{
					if (GUILayout.Button(new GUIContent("Force Reload All Items")))
					{
						PPEItems.Instance.Reload(true);
					}

					if (GUILayout.Button(new GUIContent("Delete All Items")))
					{
						if (EditorUtility.DisplayDialog("PPE - Delete All Items", "Are you sure you want to delete all items?", "Delete All", "Cancel"))
						{
							PPE.DeleteAll();
						}
					}
				}
				EditorGUILayout.EndHorizontal();
			}

			_isNeedShowItems = EditorGUILayout.Foldout(_isNeedShowItems, "Items (" + PPEItems.Instance.items.Count + ")");
			if (_isNeedShowItems)
			{
				//#region Header
				//// header
				//EditorGUILayout.BeginHorizontal(headerStyle);
				//{
				//	// index
				//	EditorGUILayout.LabelField(" ", headerGUIStyle, GUILayout.Width(30), GUILayout.MinWidth(20));

				//	// type
				//	EditorGUILayout.LabelField(new GUIContent("T", "Type"), headerGUIStyle2, GUILayout.Width(20));

				//	// crypto
				//	EditorGUILayout.LabelField(new GUIContent("C", "Crypto"), headerGUIStyle2, GUILayout.Width(20));

				//	// key/value
				//	EditorGUILayout.LabelField("Key/Value", headerGUIStyle2, GUILayout.MinWidth(50));
				//}
				//EditorGUILayout.EndHorizontal();
				//#endregion

				// separator
				//GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(1) });
				GUILayout.Space(2);

				// items
				_scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
				{
					int index = 0;

					foreach (KeyValuePair<string, PPEItem> pair in PPEItems.Instance.items)
					{
						PPEItem item = pair.Value;

						EditorGUILayout.BeginHorizontal(GUILayout.Height(25));
						{
							// index
							EditorGUILayout.LabelField((index + 1) + ".", labelCounterStyle, GUILayout.Width(20));

							// type + crypto
							var labelTypeAndCrypto = item.type.type;
							var labelTypeAndCryptoTooltip = item.type.type;

							if (item.isCrypted)
							{
								labelTypeAndCrypto += ", e";
								labelTypeAndCryptoTooltip += ", Encrypted";
							}
							else
							{
								labelTypeAndCrypto += ", n";
								labelTypeAndCryptoTooltip += ", Nonencrypted";
							}

							EditorGUILayout.LabelField(new GUIContent(labelTypeAndCrypto, labelTypeAndCryptoTooltip), labelTypeStyle, GUILayout.Width(20));

							// key
							EditorGUILayout.SelectableLabel(item.key, labelKeyStyle, GUILayout.MinWidth(50), GUILayout.MaxWidth(120), GUILayout.Height(20));

							// indicator
							EditorGUILayout.SelectableLabel("=>", labelIndicatorStyle, GUILayout.MinWidth(15), GUILayout.MaxWidth(15), GUILayout.Height(20));

							// value
							EditorGUILayout.SelectableLabel(item.stringValue, labelValueStyle, GUILayout.Height(20));

							EditorGUILayout.BeginHorizontal(GUILayout.Width(25), GUILayout.MinWidth(25), GUILayout.MaxWidth(25));
							{
								//// edit button
								//if (GUILayout.Button(new GUIContent(_editButtonTexture), buttonStyle))
								//{
								//	Debug.Log("Edit button " + index + " pressed");
								//}

								// delete button
								if (GUILayout.Button(new GUIContent(_deleteButtonTexture), itemsDeleteButtonStyle))
								{
									if (EditorUtility.DisplayDialog("PPE - Delete Key", "Are you sure you want to delete key \"" + item.key + "\"?", "Delete", "Cancel"))
									{
										PPE.DeleteKey(item.key);
									}
								}
							}
							EditorGUILayout.EndHorizontal();
						}
						EditorGUILayout.EndHorizontal();
						GUILayout.Box("", itemsSeparatorStyle, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(1) });

						index++;
					}
				}
				EditorGUILayout.EndScrollView();
			}
		}
	}
}
