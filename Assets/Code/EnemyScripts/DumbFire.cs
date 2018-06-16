using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbFire : MonoBehaviour {

    public Transform FirePoint;
	public float FireRate;
    private float fireNextPrimary = 0;
	public GameObject projectile;
	
	void Start(){
		
		fireNextPrimary = Time.time + Random.Range(0, FireRate);
	}

	void Update () {	
		if (Time.time > fireNextPrimary)
		{
			var RandomDirection = Quaternion.Euler(0,0,Random.Range(0,360));
			Instantiate(projectile, FirePoint.position, RandomDirection);
			fireNextPrimary = Time.time + FireRate;
		}
	}

}
