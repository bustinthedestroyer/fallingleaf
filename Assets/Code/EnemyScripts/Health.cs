using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int MaxHealth;
	private int currentHealth;
	public int Experience;
    public GameController gameController;
    public Player playerController;
	//public PoolController explosionPool;
	public PoolYard poolYard;
	public SpriteRenderer spriteRenderer;

	public DropsItems dropsItems;

	public float DamagePause = .1f;
	float DamageNext = 0;

	public bool Invincible;

	void Update(){
		if(Time.time > DamageNext){
			spriteRenderer.color = Color.white;
		}

		if(IsDead){
			dropsItems.DropLoot();
			gameObject.SetActive(false);
			//playerController.GainExperiance(Experience);
		}
	}

	void Awake(){
        if(gameController == null){
            gameController =  GameObject.Find("Game").GetComponent<GameController>();
        }
        if(playerController == null){
            playerController =  GameObject.Find("Player").GetComponent<Player>();
        }
		poolYard = GameObject.FindGameObjectWithTag("PoolYard").GetComponent<PoolYard>();
		// if(explosionPool == null){
		// 	explosionPool = GameObject.Find("ExplosionController").GetComponent<PoolController>();
		// }
		
	}
	void OnTriggerEnter2D(Collider2D collider)
    {
		if(!Invincible){
			if(collider.tag == "ProjectilePlayer")
			{			
				GameObject explosion = poolYard.pool_Explosion.GetPoolObject();
				explosion.transform.position = collider.transform.position;
				explosion.transform.rotation = collider.transform.rotation;
				explosion.SetActive(true);

				///Gain Resource
				//playerController.GainResouce(1);

				collider.gameObject.SetActive(false);
				TakeDamage(1);

				return;
			}
			if(collider.tag == "PlayerProjectile2")
			{
				GameObject explosion = poolYard.pool_Explosion.GetPoolObject();
				explosion.transform.position = transform.position;
				explosion.transform.rotation = transform.rotation;
				explosion.SetActive(true);

				TakeDamage(1);
				return;
			}
			if(Crashes){
				if(collider.tag == "Player")
				{
					GameObject explosion = poolYard.pool_Explosion.GetPoolObject();
					explosion.transform.position = transform.position;
					explosion.transform.rotation = transform.rotation;
					explosion.SetActive(true);

					TakeDamage(1);
					return;
				}
			}
		}
	}

	public bool Crashes;

	public bool IsDead = false;

	void TakeDamage(int damageAmount){

		spriteRenderer.color = Color.red;
		DamageNext = Time.time + DamagePause;

		currentHealth -= damageAmount;
		if(currentHealth <= 0){
			IsDead = true;
		}
	}
	
	void OnEnable(){
		currentHealth = MaxHealth;
		gameController.EnemyCount++;
		IsDead = false;
	}
	void OnDisable(){
		gameController.EnemyCount--;
		//Debug.Log("Drops");
	}



}