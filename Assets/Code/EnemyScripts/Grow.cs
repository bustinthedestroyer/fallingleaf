using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {

	public float GrowX;
	public float GrowY;

	private Transform myTransform;
	private Vector3 startScale;

	void Awake(){
		myTransform = transform;
		startScale = myTransform.localScale;
	}

	void Update () {

		//if(true){
			var tempScale = myTransform.localScale;
			tempScale.x += Time.deltaTime * GrowX;
			tempScale.y += Time.deltaTime * GrowY;
			myTransform.localScale = tempScale;
		//}

		//if(transform.localScale != MaxSize){
		//transform.localScale += new Vector3(GrowX, GrowY, 0);
		//}
	}

	void OnDisable(){
		myTransform.localScale = startScale;
	}

}
