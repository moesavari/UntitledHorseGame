using UnityEngine;
using PlayerPrefs = ZBS.PPE;

public class PPEExample2 : MonoBehaviour
{
    void Start()
    {
		Vector2[] positions = { new Vector2(100, 20), new Vector2(-1, 13) };

		var key = "positions";
		PlayerPrefs.SetVector2Array(key, positions);
		PlayerPrefs.Save();

		// ...

		if (PlayerPrefs.HasKey(key))
		{
			var savedPosition = PlayerPrefs.GetVector2Array(key);
			var startX = savedPosition[1].x;

			Debug.Log("startX = " + startX);
		}
    }
}
