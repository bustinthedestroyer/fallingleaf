using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCloud : PlayerSpecialAction {

	public GameObject Projectile;

	void Start(){
		ActionExecute = ActionThunderCLoud;
	}

	public void ActionThunderCLoud(){
		Vector2 spawnPoint = new Vector2(playerController.FirePoint.position.x, playerController.FirePoint.position.y + .25f);
        Instantiate(Projectile, spawnPoint, playerController.FirePoint.rotation);
	}

}
