using UnityEngine;
using System.Collections;

public class BirdInteraction : MonoBehaviour {

	public float bellPitchMod = 0.1f;
	public AudioClip bellSFX;
	public AudioClip popSFX;

	private GameManager gameManager;
	private ParticleSystem featherExplosion;
	private AudioSource featherSFX;
	private SceneryMovement[] sceneryMovers;

	void Awake () 
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		featherExplosion = transform.FindChild ("FeatherExplosion").gameObject.GetComponent<ParticleSystem> ();
		featherSFX = featherExplosion.gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "kill")
		{
			Die ();
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "pass")
		{
			float pitchMod = Random.Range (-bellPitchMod, bellPitchMod);
			featherSFX.pitch = 1 + pitchMod;
			featherSFX.PlayOneShot (bellSFX, 0.2f);

			gameManager.IncreaseScore ();
		}
	}

	void Die() 
	{
		featherExplosion.transform.parent = null;
		featherExplosion.Play ();
		featherSFX.PlayOneShot (popSFX, 1f);

//		sceneryMovers = FindObjectsOfType(typeof(SceneryMovement)) as SceneryMovement[];
//
//		foreach (SceneryMovement mover in sceneryMovers)
//		{
//			mover.StopMoving ();
//		}

		gameManager.StopSpawning ();

		gameObject.SetActive (false);
	}
}
