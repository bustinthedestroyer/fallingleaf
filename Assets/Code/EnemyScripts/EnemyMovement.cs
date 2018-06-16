using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private float actualSpeed;
	public float Speed;
	public float SpeedMax;
	public bool VariedSpeed;
	//private Vector2 destination;

	public MovementType MovementType;

	public Transform myTransform;

	void Awake(){
		myTransform = transform;
	}

	void Update () {

		switch(MovementType){
			case MovementType.TopToBottom:
				myTransform.Translate(0,-actualSpeed * Time.deltaTime, 0, 0);
			break;
			case MovementType.LeftToRight:
				myTransform.Translate(actualSpeed * Time.deltaTime, 0, 0);
			break;
			default:
			break;
		}
		//transform.position = Vector2.MoveTowards(transform.position, destination, actualSpeed * Time.deltaTime);
		
	}

	void OnDisable(){

	}
	void OnEnable(){
		if(VariedSpeed){
			actualSpeed = Random.Range(Speed, SpeedMax);
		}else{
			actualSpeed = Speed;
		}
	}


	// Vector2 GetDestination(){
	// 	var y = -6;
	// 	var x = Random.Range(-3f, 3f);
	// 	return new Vector2(x,y);
	// }
	
	// void OnEnable(){
	// 	destination = GetDestination();
	// }
}


public enum MovementType{
	TopToBottom,
	LeftToRight
}