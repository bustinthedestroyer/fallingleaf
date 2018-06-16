using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoEnemy : MonoBehaviour {

	public float Speed;
    // public GameObject FireBall;
    // public Transform FirePoint;
    // private float attackNext = 0;
    // public float AttackRate;
	private Vector2 destination;

	void Start(){
		//attackNext = Time.time + Random.Range(0, AttackRate);
		//destination = GetDestination();

	}

	void Update () {

		// if (Time.time > attackNext)
		// {
		// 	Instantiate(FireBall, FirePoint.position, FirePoint.rotation);
		// 	attackNext = Time.time + AttackRate;
		// }

		transform.position = Vector2.MoveTowards(transform.position, destination, Speed * Time.deltaTime);
	}

	Vector2 GetDestination(){
		var y = -6;
		var x = Random.Range(-3f, 3f);
		return new Vector2(x,y);
	}
	
	void OnEnable(){
		destination = GetDestination();
	}
}