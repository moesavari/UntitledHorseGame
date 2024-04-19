using UnityEngine;
using ZBS;

public class PPEDemo : MonoBehaviour
{
	string _secretString;
	string _name;

	void OnGUI()
	{
		GUILayout.Space(20);
		GUILayout.BeginHorizontal();
		{
			GUILayout.Space(20);
			GUILayout.Label("Secret:", GUILayout.Width(50), GUILayout.MinWidth(20));

			_secretString = GUILayout.TextField(_secretString, GUILayout.Width(100));

			if (GUILayout.Button("Save"))
			{
				if (PPE.SetString("secret", _secretString, true))
				{
					PPE.Save();

					Debug.Log("Secret saved.");
				}
			}

			if (GUILayout.Button("Load"))
			{
				_secretString = PPE.GetString("secret", "bla bla bla");

				Debug.Log("Secret loaded.");
			}
		}
		GUILayout.EndHorizontal();

		GUILayout.Space(20);
		GUILayout.BeginHorizontal();
		{
			GUILayout.Space(20);
			GUILayout.Label("Name:", GUILayout.Width(50), GUILayout.MinWidth(20));

			_name = GUILayout.TextField(_name, GUILayout.Width(100));

			if (GUILayout.Button("Save"))
			{
				if (PPE.SetString("name", _name))
				{
					PPE.Save();

					Debug.Log("Name saved.");	
				}
			}

			if (GUILayout.Button("Load"))
			{
				_name = PPE.GetString("name", "");

				Debug.Log("Name loaded.");
			}
		}
		GUILayout.EndHorizontal();
	}

	void Start()
	{
		_secretString = PPE.GetString("secret", "bla bla bla");

		if (PPE.HasKey("name"))
		{
			_name = PPE.GetString("name");
		}
		else
		{
			_name = "Daniel";
		}
	}
}
