using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour {

	public float LifeTime;

	void OnEnable () {
		if(LifeTime !=0){
			lifeSpan = Time.time + LifeTime;
		}
	}

	private float lifeSpan;

	void Update () {
		if(Time.time > lifeSpan){
        	this.gameObject.SetActive(false);
		}
	}
}
