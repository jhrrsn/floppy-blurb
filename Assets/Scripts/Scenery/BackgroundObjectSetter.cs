using UnityEngine;
using System.Collections;

public class BackgroundObjectSetter : MonoBehaviour {

	public float startPosition = 9.5f;
	public float objectHeight = 4f;

	void OnEnable ()
	{
		if (Time.timeSinceLevelLoad > 0.1f)
			ResetHorizontalPosition ();
		
		ResetVerticalPosition ();
	}

	void ResetHorizontalPosition ()
	{
		transform.position = new Vector2 (startPosition, transform.position.y);
	}

	void ResetVerticalPosition ()
	{
		transform.position = new Vector2 (transform.position.x, objectHeight);
	}
}
