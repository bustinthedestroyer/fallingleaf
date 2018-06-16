using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : PlayerSpecialAction {

	public GameObject Projectile;

	void Start(){
		ActionExecute = ActionFireBreath;
	}

	public void ActionFireBreath(){
		GameObject fireBreath = Instantiate(Projectile, playerController.FirePoint.position, playerController.FirePoint.rotation);
		fireBreath.transform.parent = playerController.transform;
	}
}