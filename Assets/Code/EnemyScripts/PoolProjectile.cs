using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolProjectile : MonoBehaviour {

	public float Speed;
	
    public Rigidbody2D theRigidbody2D;

	Transform myTransform;
	void Start (){
		myTransform = transform;
	}
	void Update(){
		myTransform.Translate(Speed * Time.deltaTime, 0, 0);
	}
}
