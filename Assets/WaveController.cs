//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	public EnemyWaveRange EnemyRangesMinion;
	public EnemyWaveRange EnemyRangesFighter;
	public EnemyWaveRange EnemyRangesChampion;
	public EnemyWaveRange EnemyRangesHero;

	public GameController gameController;
	public int WavePause;

	public PoolYard poolYard;
	private PoolController[] lootTable;

	public int WaveNumber=1;

	void Awake () {
		//WaveNumber = 1;
	}

	public IEnumerator PlayEndlessWaves(){

		EnemyRangesMinion.EnemyPool = gameController.levelController.MinionPool;
		EnemyRangesFighter.EnemyPool = gameController.levelController.FighterPool;
		EnemyRangesChampion.EnemyPool = gameController.levelController.ChampionPool;
		EnemyRangesHero.EnemyPool = gameController.levelController.HeroPool;
		
		poolYard = GameObject.FindGameObjectWithTag("PoolYard").GetComponent<PoolYard>();
		lootTable = new PoolController[]{
			poolYard.pool_item_Page,
			poolYard.pool_item_Potion,
			poolYard.pool_item_Attack
		};
		
		////Move player
		gameController.player.MovePlayerTo(new Vector2(0,-2.5f));
		yield return new WaitUntil(gameController.PlayerMovementComplete);
		

		Debug.Log(EnemyRangesMinion.EnemyPool != null);

		while(true){


			gameController.UpdateTitleText("Wave: " + WaveNumber, 1);
			
			SpawnEnemies(EnemyRangesMinion, WaveNumber);
			SpawnEnemies(EnemyRangesFighter, WaveNumber);
			SpawnEnemies(EnemyRangesChampion, WaveNumber);
			SpawnEnemies(EnemyRangesHero, WaveNumber);

			yield return new WaitUntil(gameController.AllBadGuysAreDeadOrPlayer);

			if(gameController.IsGameOver){
				
				gameController.UpdateTitleText("Died On Wave: " + WaveNumber, 3);
				WaveNumber = 1;
				break;
			}

			////SpawnItems
			DropItems();
			yield return new WaitForSeconds(WavePause);
			WaveNumber++;

		}

		yield return null;

	}
	
	private void SpawnEnemies(EnemyWaveRange enemyWaveRange, int WaveNumber){
		
		int enemyCount = UnityEngine.Random.Range((int)Mathf.Floor(WaveNumber * enemyWaveRange.EnemyChanceMin), (int)Mathf.Floor(WaveNumber * enemyWaveRange.EnemyChanceMax));
		
		for(int i=0; i<enemyCount; i++){
			var enemy = enemyWaveRange.EnemyPool.GetPoolObject();
			float x = UnityEngine.Random.Range(enemyWaveRange.EnemySpawnMinX, enemyWaveRange.EnemySpawnMaxX);
			float y = UnityEngine.Random.Range(enemyWaveRange.EnemySpawnMinY, enemyWaveRange.EnemySpawnMaxY);
			enemy.transform.position = new Vector2(x,y);
			enemy.SetActive(true);
		}

		

	}

	private void DropItems(){

		int itemCount = 1 + (int)Mathf.Floor(WaveNumber * 0.15f);

		for(int i=0; i<itemCount; i++){
			var item = lootTable[Random.Range(0,3)].GetPoolObject();
			item.transform.position = gameController.enemySpawns.GetRandomTop();
			item.SetActive(true);
			
		}
	}
}



[System.Serializable]
public class EnemyWaveRange{
	public float EnemyChanceMin;
	public float EnemyChanceMax;
	public float EnemySpawnMinX;
	public float EnemySpawnMaxX;
	public float EnemySpawnMinY;
	public float EnemySpawnMaxY;
	public PoolController EnemyPool;

}