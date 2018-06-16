using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Player player;
	public GameObject GamePanel;
	public GameObject QuitLevelMenu;
	public GameObject MenuPanel;
	public GameObject ScorePanel;
	public GameObject AdPanel;
	public LevelController levelController;
	public bool IsGameOver = false;
	public Text TitleText, textCoins, textPages, textAttack;
	public Text textCoinsTotal, textPagesTotal, textAttackTotal;
	private Level currentLevel;
	public int EnemyCount = 0;
	public event StartGameEventHandler StartGameEvent = delegate{};
	public delegate void StartGameEventHandler(bool start);
	public EnemySpawns enemySpawns;
	public PoolYard poolYard;
	public WaveController waveController;

	private bool Waves = false;
	
	void OnGUI()
	{
		///Display framerate, maybe?
		GUI.Label(new Rect(0, 0, 100, 100), ((int)(1.0f / Time.smoothDeltaTime)).ToString());        
	}

	void Start () {
		///For testing
		//StartLevel(0);
		//StartEndlessWaves();
	}
	
	void Update () {
        UpdateText();
	}

	float textTime = 0;
	void UpdateText(){
		if(Time.time > textTime){
			TitleText.text = "";
		}
	}

	
	public void StartLevel(int levelIndex){
		Waves = false;
		StartGameEvent(true);
		currentLevel = levelController.Levels[levelIndex];
        StartCoroutine(PlayLevel());
	}
	
	public void StartEndlessWaves(){
		Waves = true;
		StartGameEvent(true);
        StartCoroutine(waveController.PlayEndlessWaves());
	}

    IEnumerator PlayLevel(){
		
		foreach(LevelPart part in currentLevel.LevelParts){

			switch(part.PartType){
				case LevelPartType.EnemyWave:
					var wave = (EnemyWave)part;
					GameObject obj = null;
					foreach(Spawn spawn in wave.Spawns){
						obj = spawn.Pool.GetPoolObject();
						obj.transform.position = spawn.SpawnLocation;
						obj.SetActive(true);
					}
					yield return new WaitUntil(AllBadGuysAreDeadOrPlayer);

				break;

				case LevelPartType.StageTransition:
					var stageTransition = (StageTransition)part;
					stageTransition.Stage.ChangeColumn(stageTransition.NextX);
					if(stageTransition.WaitForChange){
						yield return new WaitUntil(()=>!stageTransition.Stage.StageTransitioning);
					}
				break;

				case LevelPartType.StageSpeedTransition:
					var stageSpeedTransition = (StageSpeedTransition)part;
					stageSpeedTransition.Stage.ChangeScrollSpeed(stageSpeedTransition.NextScrollSpeed);
					if(stageSpeedTransition.WaitForChange){
						yield return new WaitUntil(()=>!stageSpeedTransition.Stage.StageSpeedTransitioning);
					}
				break;

				case LevelPartType.PlayerTransition:
					var playerTransition = (PlayerTransition)part;
					player.MovePlayerTo(playerTransition.NextPlayerPosition);
					yield return new WaitUntil(PlayerMovementComplete);
				break;

				case LevelPartType.TextMessage:
					var TextMessage = (TextMessage)part;
					UpdateTitleText(TextMessage.MessageText, TextMessage.MessageDuration);
				break;

				case LevelPartType.ItemDrop:
					var itemSpawn = (ItemSpawn)part;
					obj = itemSpawn.ItemPool.GetPoolObject();
					obj.transform.position = enemySpawns.GetRandomTop();
					obj.SetActive(true);
				break;

				default:
				break;
			}

			if(IsGameOver){
				break;
			}


			yield return new WaitForSeconds(part.PartPause);

		}

		if(!IsGameOver){
			BeatLevel();
		}

	}

	
	public void PlayerHasDied(){
		if(!IsGameOver){
			IsGameOver = true;
			
			StartGameEvent(false);
			player.ControlEnabled = false;
			UpdateTitleText("You died!", 3);
			Invoke("BeatLevel", 3);
		}
	}

	public bool AllBadGuysAreDead(){

		return EnemyCount <= 0 ? true : false;
	}
	
	public bool AllBadGuysAreDeadOrPlayer(){
		return EnemyCount <= 0 || IsGameOver;
	}

	public bool PlayerMovementComplete(){
		return !player.ForceMoving;
	}
	
	public bool StageTransitionComplete(BackgroundScoll stage){
		return !stage.StageTransitioning;
	}


	public void BeatLevel(){
		
		//StartGameEvent(false);
		//GamePanel.SetActive(false);
		//QuitLevelMenu.SetActive(false);
		ScorePanel.SetActive(true);
		player.TotalScore();
		//MenuPanel.SetActive(true);
	}

	////Menu End Game
	public void EndGame(){
		StartGameEvent(false);
		IsGameOver = false;
		QuitLevelMenu.SetActive(false);
		ScorePanel.SetActive(false);
		MenuPanel.SetActive(true);
		GamePanel.SetActive(false);
	}

	public void ServeAd()
	{
		ScorePanel.SetActive(false);
		AdPanel.SetActive(true);

		Invoke("RetryLevel", 3);
	}
	
	public void RetryLevel(){
		IsGameOver = false;
		AdPanel.SetActive(false);
		//ScorePanel.SetActive(false);
		player.Reset();
		poolYard.ResetPools();

		if(Waves){
			StartEndlessWaves();
		}else{
			StartLevel(0);
		}

	}

	public void UpdateTitleText(string textToDisplay, float textDuration){
		TitleText.text = textToDisplay;
		textTime = Time.time + textDuration;
	}
}