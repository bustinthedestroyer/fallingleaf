using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float RotationSpeed;
	void Start () {
		//rotationSpeed = Random.Range(-100,100);
		transform.rotation = Quaternion.Euler(0,0,Random.Range(0.0f, 360.0f));
	}
	
	void Update()
	{
		transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
	}
}
