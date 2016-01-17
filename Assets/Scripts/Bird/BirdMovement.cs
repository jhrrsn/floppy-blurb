using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public float flapForce;
	public float flapDelay = 0.5f;
	public float flapPitchMod = 0.1f;
	public AudioClip flapSFX;

	private Rigidbody2D rb;
	private Animator anim;
	private AudioSource sfx;
	private float nextFlap;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sfx = GetComponent<AudioSource> ();

		nextFlap = Time.time;
	}

	void Update ()
	{
		anim.SetBool ("Flap", false);

		if (Input.GetButtonDown ("Flap") && Time.time >= nextFlap)
		{
			nextFlap = Time.time + flapDelay;
		
			Flap ();
		}
	}

	void Flap ()
	{
		anim.SetBool ("Flap", true);

		float pitchMod = Random.Range (-flapPitchMod, flapPitchMod);
		sfx.pitch = 1 + pitchMod;
		sfx.PlayOneShot (flapSFX);

		rb.AddForce (Vector2.up * flapForce);
	}
}
