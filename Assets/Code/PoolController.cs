using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {

	public GameObject PoolObject;
	public List<GameObject> PoolObjects;
	public int PoolCount;
	public bool CanGrow = true;


	void Start ()
	{
		PoolObjects = new List<GameObject>();
		for(int i=0; i < PoolCount; i++)
		{
			GameObject obj = Instantiate(PoolObject);
			obj.SetActive(false);
			PoolObjects.Add(obj);
		}
	}
	
	public GameObject GetPoolObject()
	{
		for(int i = 0; i < PoolObjects.Count; i++){
			if(!PoolObjects[i].activeInHierarchy){
				return PoolObjects[i];
			}
		}

		if(CanGrow){
			GameObject obj = Instantiate(PoolObject);
			PoolObjects.Add(obj);
			return obj;
		}

		return null;
	}

	void OnDisable(){
		Reset();
	}

	public void Reset(){
		if(PoolObjects.Count > 0){
			for(int i = 0; i < PoolObjects.Count; i++){
				if(!PoolObjects[i]) return;
				if(PoolObjects[i].activeInHierarchy){
					PoolObjects[i].SetActive(false);
				}
			}
		}
	}
}
