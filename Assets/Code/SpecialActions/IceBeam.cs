using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeam : PlayerSpecialAction {

	public GameObject Projectile;

	void Start(){
		ActionExecute = ActionIceBeam;
	}

	public void ActionIceBeam(){
		Vector2 spawnPoint = new Vector2(playerController.FirePoint.position.x, playerController.FirePoint.position.y + 5);
		GameObject beam = Instantiate(Projectile, spawnPoint, Projectile.transform.rotation);
		beam.transform.parent = playerController.transform;
	}	
}