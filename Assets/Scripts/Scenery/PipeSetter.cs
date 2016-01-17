using UnityEngine;
using System.Collections;

public class PipeSetter : MonoBehaviour {


	public float minPipeHeight = -4f;
	public float maxPipeHeight = 2f;
	public float minPipeGap = 2f;
	public float maxPipeGap = 4f;
	public float startPosition = 9.5f;

	private Transform pipeLow;
	private Transform pipeHigh;
	private float lastPipeHeight;

	void Awake ()
	{
		pipeLow = transform.FindChild("PipeLow");
		pipeHigh = transform.FindChild("PipeHigh");

//		SetLastPipeHeight ();
		SetNewPipeHeight ();
	}

	void OnEnable ()
	{
		SetNewPipeHeight ();
		ResetHorizontalPosition ();
	}


/* FOR TESTING */

//	void Update ()
//	{
//		if (Input.GetButtonDown ("Flap"))
//		{
//			SetNewPipeHeight ();
//		}
//	}

	void ResetHorizontalPosition ()
	{
		Vector2 newPosition = transform.position;
		newPosition.x = startPosition;
		transform.position = newPosition;
	}

	void SetNewPipeHeight ()
	{
		float newPipeHeight = Random.Range (minPipeHeight, maxPipeHeight);

		Vector2 pipeLowPosition = pipeLow.transform.position;

		pipeLowPosition.y = newPipeHeight;

		pipeLow.transform.position = pipeLowPosition;

//		SetLastPipeHeight ();

		float newPipeGap = Random.Range (minPipeGap, maxPipeGap);

		Vector2 pipeHighPosition = pipeHigh.transform.position;

		pipeHighPosition.y = newPipeHeight + newPipeGap;

		pipeHigh.transform.position = pipeHighPosition;
	}

//	void SetLastPipeHeight ()
//	{
//		lastPipeHeight = pipeLow.transform.position.y;
//	}
}
