using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLeave : MonoBehaviour {

	public float TimeToLive = 0;

	void Start () {
		if(TimeToLive !=0){
			Destroy(gameObject, TimeToLive);
		}
	}
}
