using UnityEngine;
using System.Collections;

public class BirdRotation : MonoBehaviour {

	public float rotationMultiplier = 1f;

	private Rigidbody2D rb;
	
	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		float horizontalVelocity = rb.velocity.y;

		transform.rotation = Quaternion.Euler (0f, 0f, horizontalVelocity * rotationMultiplier);
	}
}
