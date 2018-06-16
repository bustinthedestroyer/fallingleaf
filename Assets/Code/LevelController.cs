using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {


	public PoolController MinionPool;
	public PoolController FighterPool;
	public PoolController ChampionPool;
	public PoolController HeroPool;
	public PoolController BossPool;

	public BackgroundScoll Background;
	public BackgroundScoll Midground;
	public BackgroundScoll Foreground;
	public Player Player;

	public PoolYard poolYard;



	public Level[] Levels;


	void Awake(){

		MinionPool = poolYard.pool_Minion;
		ChampionPool = poolYard.pool_Champion;
		HeroPool = poolYard.pool_Hero;
		BossPool = poolYard.pool_Boss;
		FighterPool = poolYard.pool_Fighter;

		
		Levels = new Level[]{
			new Level(){
				LevelTitle = "Test Level",
				LevelParts = new LevelPart[]{
					new TextMessage("Tesd Tesert",2),
					new PlayerTransition(new Vector2(0,-2.5f)),

					//////Phase 1
					new ItemSpawn(poolYard.pool_item_Attack, 1),

					new EnemyWave(
						new Spawn[]{
							new Spawn(1, 6f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(-1, 6f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(-.5f ,6f, MinionPool)
							,new Spawn(.5f, 7f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(-1, 6f, MinionPool)
							,new Spawn(0, 8f, MinionPool)
							,new Spawn(1, 7f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(-1.5f, 6f, MinionPool)
							,new Spawn(-1.5f, 7f, MinionPool)
							,new Spawn(-1.5f, 8f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(1f, 6f, MinionPool)
							,new Spawn(1f, 7f, MinionPool)
							,new Spawn(1f, 8f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(-.5f, 7f, MinionPool)
							,new Spawn(-1f, 8f, MinionPool)
							,new Spawn(-1.5f, 9f, MinionPool)
							,new Spawn(-2f, 10f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(.5f, 7f, MinionPool)
							,new Spawn(1f, 8f, MinionPool)
							,new Spawn(1.5f, 9f, MinionPool)
							,new Spawn(2f, 10f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(.5f, 7f, MinionPool)
							,new Spawn(1f, 8f, MinionPool)
							,new Spawn(1.5f, 9f, MinionPool)
							,new Spawn(2f, 10f, MinionPool)
							,new Spawn(2f, 11f, MinionPool)
							,new Spawn(2f, 12f, MinionPool)
							,new Spawn(1.5f, 13f, MinionPool)
							,new Spawn(1f, 14f, MinionPool)
							,new Spawn(.5f, 15f, MinionPool)
							,new Spawn(0f, 16f, MinionPool)
						}),

					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(-.5f, 7f, MinionPool)
							,new Spawn(-1f, 8f, MinionPool)
							,new Spawn(-1.5f, 9f, MinionPool)
							,new Spawn(-2f, 10f, MinionPool)
							,new Spawn(-2f, 11f, MinionPool)
							,new Spawn(-2f, 12f, MinionPool)
							,new Spawn(-1.5f, 13f, MinionPool)
							,new Spawn(-1f, 14f, MinionPool)
							,new Spawn(-.5f, 15f, MinionPool)
							,new Spawn(-0f, 16f, MinionPool)
						},2),				
					
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(.5f, 6f, MinionPool)
							,new Spawn(.5f, 7f, MinionPool)
							,new Spawn(1f, 7f, MinionPool)
							,new Spawn(1f, 8f, MinionPool)
							,new Spawn(1.5f, 8f, MinionPool)
							,new Spawn(1.5f, 9f, MinionPool)
							,new Spawn(2f, 9f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(-.5f, 6f, MinionPool)
							,new Spawn(-.5f, 7f, MinionPool)
							,new Spawn(-1f, 7f, MinionPool)
							,new Spawn(-1f, 8f, MinionPool)
							,new Spawn(-1.5f, 8f, MinionPool)
							,new Spawn(-1.5f, 9f, MinionPool)
							,new Spawn(-2f, 9f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(.5f, 6.5f, MinionPool)
							,new Spawn(-.5f, 6.5f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(.5f, 6.5f, MinionPool)
							,new Spawn(-.5f, 6.5f, MinionPool)
							,new Spawn(1f, 7f, MinionPool)
							,new Spawn(-1f, 7f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(.5f, 6.5f, MinionPool)
							,new Spawn(-.5f, 6.5f, MinionPool)
							,new Spawn(1f, 7f, MinionPool)
							,new Spawn(-1f, 7f, MinionPool)
							,new Spawn(1.5f, 7.5f, MinionPool)
							,new Spawn(-1.5f, 7.5f, MinionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(0f, 6f, MinionPool)
							,new Spawn(.5f, 6.5f, MinionPool)
							,new Spawn(-.5f, 6.5f, MinionPool)
							,new Spawn(1f, 7f, MinionPool)
							,new Spawn(-1f, 7f, MinionPool)
							,new Spawn(1.5f, 7.5f, MinionPool)
							,new Spawn(-1.5f, 7.5f, MinionPool)
							,new Spawn(2f, 8f, MinionPool)
							,new Spawn(-2f, 8f, MinionPool)
						}),
					
					new ItemSpawn(poolYard.pool_item_Attack, 1),

					////Phase 2

					new ItemSpawn(poolYard.pool_item_Page, 0),
					new EnemyWave(
						new Spawn[]{
							new Spawn(2f, 6f, FighterPool)
						},2),
					new EnemyWave(
						new Spawn[]{
							new Spawn(-2f, 6f, FighterPool)
						},1),
						
					new EnemyWave(
						new Spawn[]{
							new Spawn(-1f, 7.5f, FighterPool)

							,new Spawn(2f, 6f, MinionPool)
							,new Spawn(2f, 7f, MinionPool)
							,new Spawn(2f, 8f, MinionPool)
							,new Spawn(1.5f, 9f, MinionPool)
							,new Spawn(1f, 10f, MinionPool)
							,new Spawn(.5f, 11f, MinionPool)
							,new Spawn(0f, 12f, MinionPool)
						},1),

					new EnemyWave(
						new Spawn[]{
							new Spawn(1f, 7.5f, FighterPool)

							,new Spawn(-2f, 6f, MinionPool)
							,new Spawn(-2f, 7f, MinionPool)
							,new Spawn(-2f, 8f, MinionPool)
							,new Spawn(-1.5f, 9f, MinionPool)
							,new Spawn(-1f, 10f, MinionPool)
							,new Spawn(-.5f, 11f, MinionPool)
							,new Spawn(-0f, 12f, MinionPool)
						},2),
						
					new EnemyWave(
						new Spawn[]{
							new Spawn(-1f, 5.5f, FighterPool)

							,new Spawn(-1.5f, 8.5f, MinionPool)
							,new Spawn(-1f, 8f, MinionPool)
							,new Spawn(-.5f, 8.5f, MinionPool)
						},1),
					new EnemyWave(
						new Spawn[]{
							new Spawn(1f, 5.5f, FighterPool)

							,new Spawn(1.5f, 8.5f, MinionPool)
							,new Spawn(1f, 8f, MinionPool)
							,new Spawn(.5f, 8.5f, MinionPool)
						},1),

					new EnemyWave(
						new Spawn[]{
							new Spawn(-1.5f, 7.5f, FighterPool)

							,new Spawn(2f, 9f, MinionPool)
							,new Spawn(1.5f, 8.5f, MinionPool)
							,new Spawn(1f, 8f, MinionPool)
							,new Spawn(1f, 9f, MinionPool)
							,new Spawn(.5f, 8.5f, MinionPool)
							,new Spawn(0f, 9f, MinionPool)
						},1),

					new EnemyWave(
						new Spawn[]{
							new Spawn(1.5f, 7.5f, FighterPool)

							,new Spawn(-2f, 9f, MinionPool)
							,new Spawn(-1.5f, 8.5f, MinionPool)
							,new Spawn(-1f, 8f, MinionPool)
							,new Spawn(-1f, 9f, MinionPool)
							,new Spawn(-.5f, 8.5f, MinionPool)
							,new Spawn(0f, 9f, MinionPool)
						},1),

					new EnemyWave(
						new Spawn[]{
							new Spawn(1.5f, 6.5f, FighterPool)
							,new Spawn(0f, 6f, FighterPool)
							,new Spawn(-1.5f, 6.5f, FighterPool)
							
							,new Spawn(0f, 8f, MinionPool)
							,new Spawn(.5f, 8.5f, MinionPool)
							,new Spawn(-.5f, 8.5f, MinionPool)
							,new Spawn(1f, 9f, MinionPool)
							,new Spawn(-1f, 9f, MinionPool)
							,new Spawn(1.5f, 9.5f, MinionPool)
							,new Spawn(-1.5f, 9.5f, MinionPool)
							,new Spawn(2f, 10f, MinionPool)
							,new Spawn(-2f, 10f, MinionPool)

						},1),
						
					new ItemSpawn(poolYard.pool_item_Special, 3),

					
					new EnemyWave(
						new Spawn[]{

					 		new Spawn(0f, 6f, FighterPool)
					 		,new Spawn(0f, 8f, FighterPool)
					 		,new Spawn(0f, 10f, FighterPool)

							,new Spawn(.5f, 6f, MinionPool)
							,new Spawn(-.5f, 6f, MinionPool)

							,new Spawn(0f, 7f, MinionPool)
							,new Spawn(1f, 7f, MinionPool)

							,new Spawn(.5f, 8f, MinionPool)
							,new Spawn(1.5f, 8f, MinionPool)

							,new Spawn(1f, 9f, MinionPool)
							,new Spawn(2f, 9f, MinionPool)

							,new Spawn(1f, 10f, MinionPool)
							,new Spawn(2f, 10f, MinionPool)

							,new Spawn(1f, 11f, MinionPool)
							,new Spawn(2f, 11f, MinionPool)
							
							,new Spawn(.5f, 12f, MinionPool)
							,new Spawn(1.5f, 12f, MinionPool)
							
							,new Spawn(0f, 13f, MinionPool)
							,new Spawn(1f, 13f, MinionPool)

							
							,new Spawn(.5f, 14f, MinionPool)
							,new Spawn(-.5f, 14f, MinionPool)

							,new Spawn(0f, 15f, MinionPool)
							,new Spawn(-1f, 15f, MinionPool)

							,new Spawn(-.5f, 16, MinionPool)
							,new Spawn(-1.5f, 16, MinionPool)

							,new Spawn(-1f, 17f, MinionPool)
							,new Spawn(-2f, 17f, MinionPool)

							,new Spawn(-1f, 18f, MinionPool)
							,new Spawn(-2f, 18f, MinionPool)

							,new Spawn(-1f, 19f, MinionPool)
							,new Spawn(-2f, 19f, MinionPool)
							
							,new Spawn(-.5f, 20f, MinionPool)
							,new Spawn(-1.5f, 20f, MinionPool)
							
							,new Spawn(0f, 21f, MinionPool)
							,new Spawn(-1f, 21f, MinionPool)
						}),

					//Phase 3
					
					new ItemSpawn(poolYard.pool_item_Page, 0),
					new EnemyWave(
						new Spawn[]{
							new Spawn(1, 5.5f, ChampionPool)
						}),
					new EnemyWave(
						new Spawn[]{
							new Spawn(-1f, 5.5f, MinionPool)
							,new Spawn(-1f, 5.5f, FighterPool)
							,new Spawn(-1f, 5.5f, ChampionPool)
						}),

					new EnemyWave(
						new Spawn[]{
							new Spawn(1, 5.5f, ChampionPool)

							,new Spawn(1.25f, 11f, MinionPool)
							,new Spawn(.75f, 11f, MinionPool)
							,new Spawn(1.25f, 11.5f, MinionPool)
							,new Spawn(.75f, 11.5f, MinionPool)
						}),

					new EnemyWave(
						new Spawn[]{
							new Spawn(-1, 5.5f, ChampionPool)

							,new Spawn(-1.25f, 11f, MinionPool)
							,new Spawn(-.75f, 11f, MinionPool)
							,new Spawn(-1.25f, 11.5f, MinionPool)
							,new Spawn(-.75f, 11.5f, MinionPool)
						}),
						

					new EnemyWave(
						new Spawn[]{
							new Spawn(1, 5.5f, ChampionPool)

							,new Spawn(-1.5f, 7.5f, FighterPool)

							,new Spawn(-1.25f, 15.5f, MinionPool)
							,new Spawn(-1.5f, 15f, MinionPool)
							,new Spawn(-1.75f, 15.5f, MinionPool)
						}),

					new EnemyWave(
						new Spawn[]{
							new Spawn(-1, 5.5f, ChampionPool)

							,new Spawn(1.5f, 7.5f, FighterPool)

							,new Spawn(1.25f, 15.5f, MinionPool)
							,new Spawn(1.5f, 15f, MinionPool)
							,new Spawn(1.75f, 15.5f, MinionPool)
						}),

					new EnemyWave(
						new Spawn[]{
							new Spawn(0, 5.5f, ChampionPool)

							,new Spawn(1.5f, 7.5f, FighterPool)
							,new Spawn(-1.5f, 7.5f, FighterPool)

							,new Spawn(1.25f, 15.5f, MinionPool)
							,new Spawn(1.5f, 15f, MinionPool)
							,new Spawn(1.75f, 15.5f, MinionPool)

							,new Spawn(-1.25f, 15.5f, MinionPool)
							,new Spawn(-1.5f, 15f, MinionPool)
							,new Spawn(-1.75f, 15.5f, MinionPool)
						}),
					
					new ItemSpawn(poolYard.pool_item_Potion, 2),
					new EnemyWave(
						new Spawn[]{
							new Spawn(.5f, 5.5f, ChampionPool)
							,new Spawn(-1f, 7.5f, ChampionPool)
							,new Spawn(-.25f, 9.5f, ChampionPool)

							,new Spawn(2f, 6.5f, FighterPool)
							,new Spawn(-1.5f, 9.5f, FighterPool)

							,new Spawn(1.25f, 15f, MinionPool)
							,new Spawn(1.5f, 17f, MinionPool)
							,new Spawn(1.75f, 13f, MinionPool)

							,new Spawn(-.25f, 10f, MinionPool)
							,new Spawn(0f, 8f, MinionPool)
							,new Spawn(-.25f, 12f, MinionPool)

							,new Spawn(-1f, 8.5f, ChampionPool)

							,new Spawn(-.5f, 14f, FighterPool)
							,new Spawn(1.5f, 15f, FighterPool)

							,new Spawn(-1.25f, 25f, MinionPool)
							,new Spawn(-1.5f, 27f, MinionPool)
							,new Spawn(-1.75f, 23f, MinionPool)

							,new Spawn(1.25f, 20f, MinionPool)
							,new Spawn(1.5f, 18f, MinionPool)
							,new Spawn(1.75f, 22f, MinionPool)
							
							,new Spawn(-2f, 10.5f, FighterPool)
							,new Spawn(1.75f, 12f, FighterPool)

							,new Spawn(-.25f, 35f, MinionPool)
							,new Spawn(-0f, 37f, MinionPool)
							,new Spawn(-.25f, 33f, MinionPool)

							,new Spawn(1.25f, 30f, MinionPool)
							,new Spawn(1.5f, 38f, MinionPool)
							,new Spawn(1.75f, 32f, MinionPool)
							
							,new Spawn(1.25f, 45f, MinionPool)
							,new Spawn(1.5f, 47f, MinionPool)
							,new Spawn(1.75f, 43f, MinionPool)

							,new Spawn(-1.25f, 40f, MinionPool)
							,new Spawn(-1.5f, 38f, MinionPool)
							,new Spawn(-1.75f, 42f, MinionPool)
						}),
						
					
					
					////Bring the storm
					new TextMessage("A storm comes!",2),
					new StageTransition{
						Stage = Foreground,
						NextX = .25f,
						WaitForChange = true
					},
					new StageTransition{
						Stage = Foreground,
						NextX = .5f,
						WaitForChange = true
					},

					new ItemSpawn(poolYard.pool_item_Page, 0),

					new EnemyWave(
						new Spawn[]{
					 		new Spawn(-4f, 3f, HeroPool)
						},2),

					new EnemyWave(
						new Spawn[]{
							new Spawn(-4, 4f, HeroPool)
							,new Spawn(-7f, 2f, HeroPool)
						},1),

					new EnemyWave(
						new Spawn[]{
							new Spawn(-4f, 3f, HeroPool)
							,new Spawn(-7f, 4f, HeroPool)
							,new Spawn(-9f, 2, HeroPool)
						}),

					new ItemSpawn(poolYard.pool_item_Potion, 1),
					new ItemSpawn(poolYard.pool_item_Attack, 3),

					//Phase 4

					
					new EnemyWave(
						new Spawn[]{
					 		new Spawn(-4f, 3f, HeroPool)
							 
							,new Spawn(1.5f, 7f, MinionPool)
							,new Spawn(1.75f, 7.5f, MinionPool)
							,new Spawn(1.25f, 7.5f, MinionPool)
							,new Spawn(1.5f, 8f, MinionPool)
						},1),

					new EnemyWave(
						new Spawn[]{
							new Spawn(-4, 4f, HeroPool)
							,new Spawn(-7f, 2f, HeroPool)
							
							,new Spawn(1.75f, 6.5f, FighterPool)
							
							,new Spawn(0f, 10f, MinionPool)
							,new Spawn(.5f, 10.5f, MinionPool)
							,new Spawn(-.5f, 10.5f, MinionPool)
							,new Spawn(0f, 10f, MinionPool)
						},2),

					new EnemyWave(
						new Spawn[]{
							new Spawn(-7f, 3f, HeroPool)
							,new Spawn(-9f, 4f, HeroPool)
							,new Spawn(-11f, 2, HeroPool)
							
							,new Spawn(.5f, 10.5f, FighterPool)
							
							,new Spawn(1.5f, 6.5f, ChampionPool)

							,new Spawn(-1.5f, 13f, MinionPool)
							,new Spawn(-1.75f, 13.5f, MinionPool)
							,new Spawn(-1.25f, 13.5f, MinionPool)
							,new Spawn(-1.5f, 14f, MinionPool)
						}, 3),
					
					new ItemSpawn(poolYard.pool_item_Special, 1),

					new EnemyWave(
						new Spawn[]{

					 		new Spawn(1f, 6f, FighterPool)
					 		,new Spawn(2f, 7f, FighterPool)
					 		,new Spawn(-1f, 8f, FighterPool)
					 		,new Spawn(-2f, 7f, FighterPool)

							,new Spawn(-4f, 2f, HeroPool)
							,new Spawn(-7f, 3f, HeroPool)
							,new Spawn(-10f, 4, HeroPool)

					 		,new Spawn(-1.5f, 5.5f, ChampionPool)
					 		,new Spawn(1.5f, 6.5f, ChampionPool)

							,new Spawn(.5f, 6f, MinionPool)
							,new Spawn(0f, 6f, MinionPool)
							,new Spawn(-.5f, 6f, MinionPool)

							,new Spawn(0f, 7f, MinionPool)
							,new Spawn(-.5f, 7f, MinionPool)
							,new Spawn(-1f, 7f, MinionPool)

							,new Spawn(-.5f, 8, MinionPool)
							,new Spawn(-1f, 8, MinionPool)
							,new Spawn(-1.5f, 8, MinionPool)

							,new Spawn(-1f, 9f, MinionPool)
							,new Spawn(-1.5f, 9f, MinionPool)
							,new Spawn(-2f, 9f, MinionPool)

							,new Spawn(-1f, 10f, MinionPool)
							,new Spawn(-1.5f, 10f, MinionPool)
							,new Spawn(-2f, 10f, MinionPool)

							,new Spawn(-1f, 11f, MinionPool)
							,new Spawn(-1.5f, 11f, MinionPool)
							,new Spawn(-2f, 11f, MinionPool)
							
							,new Spawn(-.5f, 12f, MinionPool)
							,new Spawn(-1f, 12f, MinionPool)
							,new Spawn(-1.5f, 12f, MinionPool)
							
							,new Spawn(0f, 13f, MinionPool)
							,new Spawn(-.5f, 13f, MinionPool)
							,new Spawn(-1f, 13f, MinionPool)


							,new Spawn(.5f, 14f, MinionPool)
							,new Spawn(0f, 14f, MinionPool)
							,new Spawn(-.5f, 14f, MinionPool)

							,new Spawn(0f, 15f, MinionPool)
							,new Spawn(.5f, 15f, MinionPool)
							,new Spawn(1f, 15f, MinionPool)

							,new Spawn(.5f, 16f, MinionPool)
							,new Spawn(1f, 16f, MinionPool)
							,new Spawn(1.5f, 16f, MinionPool)

							,new Spawn(1f, 17f, MinionPool)
							,new Spawn(1.5f, 17f, MinionPool)
							,new Spawn(2f, 17f, MinionPool)

							,new Spawn(1f, 18f, MinionPool)
							,new Spawn(1.5f, 18f, MinionPool)
							,new Spawn(2f, 18f, MinionPool)

							,new Spawn(1f, 19f, MinionPool)
							,new Spawn(1.5f, 19f, MinionPool)
							,new Spawn(2f, 19f, MinionPool)
							
							,new Spawn(.5f, 20f, MinionPool)
							,new Spawn(1f, 20f, MinionPool)
							,new Spawn(1.5f, 20f, MinionPool)
							
							,new Spawn(0f, 21f, MinionPool)
							,new Spawn(.5f, 21f, MinionPool)
							,new Spawn(1f, 21f, MinionPool)

							
						}),


					////Leave Storm
					new TextMessage("The clouds are parting?",1),
					new StageTransition{
						Stage = Foreground,
						NextX = .75f,
						WaitForChange = true
					},
					new StageTransition{
						Stage = Foreground,
						NextX = .0f,
					},
					
					////Clear Skys
					new StageTransition{
						Stage = Midground,
						NextX = .25f,
						WaitForChange = true
					},
					new StageTransition{
						Stage = Midground,
						NextX = .5f,
					},					
					new TextMessage("Neat, pyramids.",2){PartPause=2},
					new EnemyWave(new Spawn[]{
							new Spawn(0, 5.5f, BossPool)
						}, 3),
					new TextMessage("Level Conquered!",2),
					new PlayerTransition(new Vector2(0,6))
					
				}
			}			
		};

	}

}


public enum LevelPartType{
	EnemyWave,
	StageTransition,
	StageSpeedTransition,
	PlayerTransition,
	TextMessage,
	ItemDrop
	//Change Music
	//Dragon Speak
}

[System.Serializable]
public class Level {

	public string LevelTitle;
	public LevelPart[] LevelParts;
}

[System.Serializable]
public class LevelPart{
	public LevelPartType PartType;
	public float PartPause;

}




[System.Serializable]
public class EnemyWave : LevelPart {
	public EnemyWave(Spawn[] spawns, float pause = 0){
		PartType = LevelPartType.EnemyWave;
		Spawns = spawns;
		PartPause = pause;
	}
	public Spawn[] Spawns;
}
[System.Serializable]
public class PlayerTransition : LevelPart {
	public PlayerTransition(Vector2 nextPlayerPosition){
		NextPlayerPosition = nextPlayerPosition;
		PartType = LevelPartType.PlayerTransition;
	}
	public Vector2 NextPlayerPosition;
}
[System.Serializable]
public class StageTransition : LevelPart {
	public StageTransition(){
		PartType = LevelPartType.StageTransition;
	}
	public BackgroundScoll Stage;
	public float NextX;
	public bool WaitForChange = false;
}
[System.Serializable]
public class TextMessage : LevelPart {
	public TextMessage(string messageText, float messageDuration){
		PartType = LevelPartType.TextMessage;
		MessageText = messageText;
		MessageDuration = messageDuration;
	}
	public string MessageText;
	public float MessageDuration;
}
[System.Serializable]
public class StageSpeedTransition : LevelPart {
	public StageSpeedTransition(){
		PartType = LevelPartType.StageSpeedTransition;
	}
	public BackgroundScoll Stage;
	public float NextScrollSpeed;
	public bool WaitForChange = false;
}

[System.Serializable]
public class Spawn{

	public Spawn(float x, float y, PoolController pool)
	{
		SpawnLocation = new Vector2(x,y);
		Pool = pool;
	}
	public Vector2 SpawnLocation;
	public PoolController Pool;
}


[System.Serializable]
public class ItemSpawn : LevelPart {
	public ItemSpawn(PoolController TypeOfItem, float pause = 0){
		PartType = LevelPartType.ItemDrop;
		ItemPool = TypeOfItem;
		PartPause = pause;
	}
	public PoolController ItemPool;
}