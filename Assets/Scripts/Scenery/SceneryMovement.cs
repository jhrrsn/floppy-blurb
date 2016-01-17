using UnityEngine;
using System.Collections;

public class SceneryMovement : MonoBehaviour {

	public float moveSpeed;
	public float offscreenPosition = -9.5f;

	private Rigidbody2D rb;
	private bool moving;

	void Start () 
	{
		moving = true;
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () 
	{
		if (moving)
		{
			Vector2 targetPosition = (Vector2)transform.position + Vector2.left;
			Vector2 newPosition = Vector2.MoveTowards ((Vector2)transform.position, targetPosition, moveSpeed * Time.deltaTime);

			if (rb != null)
			{
				rb.MovePosition (newPosition);
			} 
			else
			{
				transform.position = newPosition;
			}

			if (transform.position.x < offscreenPosition)
			{
				gameObject.SetActive (false);
			}
		}
	}

	public void StopMoving()
	{
		moving = false;
	}
}
