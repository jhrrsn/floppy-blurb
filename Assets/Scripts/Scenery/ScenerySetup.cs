using UnityEngine;
using System.Collections;

public class ScenerySetup : MonoBehaviour {

	public PoolManager cloudPool;
	public int cloudPosition;
	public int cloudSpacing;

	public PoolManager hillPool;
	public int hillPosition;
	public int hillSpacing;

	void Start ()
	{
		for (int i = -cloudPosition; i <= cloudPosition; i += cloudSpacing)
		{
			GameObject obj = cloudPool.GetPooledObject ();

			obj.SetActive (true);

			Vector2 newPosition = obj.transform.position;
			newPosition.x = i;
			obj.transform.position = newPosition;
		}

		for (int i = -hillPosition; i <= hillPosition; i += hillSpacing)
		{
			GameObject obj = hillPool.GetPooledObject ();

			obj.SetActive (true);

			Vector2 newPosition = obj.transform.position;
			newPosition.x = i;
			obj.transform.position = newPosition;
		}
	}
}
