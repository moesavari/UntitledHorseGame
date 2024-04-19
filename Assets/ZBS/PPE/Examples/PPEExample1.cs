using UnityEngine;
using System;
using System.Collections.Generic;
using ZBS;

public class PPEExample1 : MonoBehaviour
{
	void Start()
	{
		PPE.SetInt("lastLevel", 34, true); // crypto
		PPE.Save();
		// ...
		int lastLevel = PPE.GetInt("lastLevel");
		Debug.Log("lastLevel = " + lastLevel);

		////////////////////////////////////////////////////////////////////////////////////////////

		var color = Color.cyan;
		var foo = new Foo();
		foo.a = 12;
		foo.b = -1254.0f;
		foo.c = true;

		PPE.SetObject("foo", foo, true); // crypto
		PPE.SetColor("color", color);
		PPE.Save();
		// ...
		Foo savedFoo = (Foo)PPE.GetObject("foo");
		Color savedColor = PPE.GetColor("color");
		Debug.Log("savedFoo.b = " + savedFoo.b);
		Debug.Log("savedColor = " + savedColor);

		////////////////////////////////////////////////////////////////////////////////////////////

		PPE.SetDateTime("lastGameDate", DateTime.Now);
		PPE.SetBoolList("settings", new List<bool> { true, false, false }, true); // crypto
		PPE.Save();
		// ...
		DateTime lastGameDate = PPE.GetDateTime("lastGameDate");
		List<bool> savedSettings = PPE.GetBoolList("settings");

		Debug.Log("lastGameDate = " + lastGameDate);
		Debug.Log("savedSettings[1] = " + savedSettings[1]);
	}
}

[Serializable]
public class Foo
{
	public int a;
	public float b;
	public bool c;
}
