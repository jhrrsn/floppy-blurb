using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

	public static PoolManager current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = false;

	private List<GameObject> pooledObjects;

	void Awake () 
	{
		current = this;

		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
			obj.transform.SetParent (this.transform);
		}
	}

	void Start () 
	{
		
	}

	public GameObject GetPooledObject () {
		foreach (GameObject obj in pooledObjects)
		{
			if (!obj.activeInHierarchy)
			{
				return obj;
			}
		}

		if (willGrow)
		{
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
			return obj;
		}

		return null;
	}
}
