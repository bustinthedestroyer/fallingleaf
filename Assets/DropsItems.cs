using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsItems : MonoBehaviour {

	public PoolYard poolYard;
	public bool DropsLoot;

	void OnEnable () {
		///TODO Recoil?
		//TODO Double Barrel
	}
	void Update(){

	}

	void Awake(){
		poolYard = GameObject.FindGameObjectWithTag("PoolYard").GetComponent<PoolYard>();
		lootTable = new PoolController[]{
			poolYard.pool_item_Page,
			poolYard.pool_item_Potion,
			poolYard.pool_item_Attack
		};

	}

	public int coinsMin, coinsMax;
	public float lootDropRadius;

	public void DropCoins(){
		int coinCount = Random.Range(coinsMin, coinsMax);
		for(int i=0;i<coinCount;i++){
		
			GameObject obj = poolYard.pool_item_Coin.GetPoolObject();
			if(obj == null) return;			
			obj.transform.position = transform.position + (Vector3)(Random.insideUnitCircle * lootDropRadius);
			obj.transform.rotation = transform.rotation;
			obj.SetActive(true);
		}

		if(DropsLoot){
			PoolController theLootPool = lootTable[Random.Range(0,3)];
			GameObject obj;
			obj= theLootPool.GetPoolObject();
			if(obj == null) return;			
			obj.transform.position = transform.position + (Vector3)(Random.insideUnitCircle * lootDropRadius);
			obj.transform.rotation = transform.rotation;
			obj.SetActive(true);
		}
	}

	public PoolController[] lootTable;
	public void DropItems(){
		
	}

	public void DropLoot(){
		
		DropCoins();
		DropItems();
		// GameObject obj = poolYard.pool_item_Coin.GetPoolObject();

		// if(obj == null) return;
		// obj.transform.position = transform.position;
		// obj.transform.rotation = transform.rotation;
		// obj.SetActive(true);
	}



}
