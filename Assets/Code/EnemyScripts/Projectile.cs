using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float Speed;
	
    public Rigidbody2D theRigidbody2D;
	void Start () {
		Go();
	}
	public void Go(){
		theRigidbody2D.AddForce(transform.right * Speed);
	}
}