using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenuController : MonoBehaviour {

	public CanvasGroup PauseMenuCanvas;

	public delegate void PauseEventHandler(bool IsPaused);
	public event PauseEventHandler EventPauseGame = delegate{};
	private float gameSpeed = 1;
	bool gameon = true;
	public float PauseSpeed;// = .025f;
	private bool paused = false;
	private bool pausing = false;
	public GameController gameController;

	void Awake(){
		////TODO This should live somewhere else
		gameController.StartGameEvent += (bool start) => {GameStart(start);};
	}
	void OnDisable(){
		Time.timeScale = 1;
	}

	public void GameStart(bool start){
		if(start){
			gameon = true;
			StartCoroutine(TimeLord());
		}else{
			PauseMenuCanvas.alpha = 0;
			gameon = false;
			gameSpeed = 1;
			paused = false;
			pausing = false;
		}
	}
	
	public void StartPause(bool pause){
		pausing = pause;
	}

	IEnumerator TimeLord(){
		while(gameon){
			
			if(pausing){
				///Slow time to stop
				if(gameSpeed > 0){
					gameSpeed -= PauseSpeed;
				}
			}else{
				///Increase time to normal
				if(gameSpeed < 1){
					gameSpeed += PauseSpeed;
				}
			}
			
			///Update speed and alpha channel
			gameSpeed = (float)System.Math.Round(gameSpeed,3);
			PauseMenuCanvas.alpha = 1 - gameSpeed;
			Time.timeScale = gameSpeed;

			//Game is fully paused
			if(gameSpeed == 0 && !paused){
				paused = true;
				EventPauseGame(true);
				PauseMenuCanvas.interactable = true;
			}

			///Game is unpausing
			if(paused && !pausing){
				paused = false;
				PauseMenuCanvas.interactable = false;
				EventPauseGame(false);
			}

			yield return null;
		}
		Debug.Log("ending Time lord");
	}

}
