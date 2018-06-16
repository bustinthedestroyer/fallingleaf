using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public Player player;

	public void Start(){
	}

	public void ExitGame(){
		Debug.Log("Game exiting");
		Application.Quit();
	}


	public void PlayLevel(){

	}
}
