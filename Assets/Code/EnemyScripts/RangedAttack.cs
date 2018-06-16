using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

    public GameObject Projectile;
    public Transform FirePoint;


	public FireRateType fireRateType;
    public float FireRate;
    private float fireNext = 0;
    public float BurstFireRate;
	public int BurstFireCount;
	private int burstFireCount = 0;
    private float burstFireNext = 0;

	public SpreadFireType multiFireType;
	public float MultiFireDistance;
	public int MultiFireCount;

	public PoolYard poolYard;

	public Player player;
	//PoolController pj;

	public bool StaggerStart;
	public float DelayStart = 0;

	void OnEnable () {
		///TODO Recoil?
		//TODO Double Barrel
	}

	void OnDisable(){
		OnScreen = false;
	}

	void Awake(){
		poolYard = GameObject.FindGameObjectWithTag("PoolYard").GetComponent<PoolYard>();
		if(Aims){
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		}
	}

	private bool OnScreen = false;
	
	void Update () {
		if(OnScreen){

			switch(fireRateType){
				case FireRateType.Single:
					if (Time.time > fireNext)
					{
						Fire();
						fireNext = Time.time + FireRate;
					}
					break;
				case FireRateType.Burst:
					if (Time.time > fireNext)
					{
						if(Time.time > burstFireNext)
						{
							Fire();
							burstFireNext = Time.time + BurstFireRate;
							burstFireCount++;

							if(burstFireCount == BurstFireCount){
								fireNext = Time.time + FireRate;
								burstFireCount = 0;
							}
						}
					}
					break;
				default:
					break;

			}
		}

		if(!OnScreen){
			OnScreen = ScreenManager.IsOnScreen(transform.position);
			if(OnScreen){
				if(DelayStart!=0){
					fireNext = Time.time + DelayStart;
				}

				if(StaggerStart){
					fireNext = Time.time + Random.Range(0, FireRate);
				}
			}
		}

	}

	public void Fire(){

		switch(multiFireType){
			case SpreadFireType.Straight:

				///TODO account for firepoint angle?
				//Vector2 bottomPosition = new Vector2(FirePoint.position.x- MultiFireDistance * (MultiFireCount / 2), FirePoint.position.y );
				var bottomx =  MultiFireDistance *.5f;
				var space = MultiFireDistance / (MultiFireCount -1 == 0 ? 1:MultiFireCount -1);
				Vector2 bottomPosition = new Vector2(FirePoint.position.x - bottomx, FirePoint.position.y);
				for (int i = 0; i < MultiFireCount; i++)
				{
					Vector3 ProjectilePosition = new Vector2(bottomPosition.x + i * space, bottomPosition.y);
					FireProjectile(ProjectilePosition, FirePoint.rotation);
				}
				break;
			case SpreadFireType.Angled:
				///TODO Account for tail fan, spawn position
				float baseRotation = FirePoint.rotation.eulerAngles.z - ((MultiFireCount -1) * MultiFireDistance) * .5f;
				for (int i = 0; i < MultiFireCount; i++)
				{
					float ProjectileAngle = baseRotation + i * MultiFireDistance;
					FireProjectile(FirePoint.position, Quaternion.Euler(0,0,ProjectileAngle));
				}
				break;
			default:
				FireProjectile(FirePoint.position, FirePoint.rotation);
				break;
		}

	}

	public bool Aims;
	
	public void FireProjectile(Vector2 projectilePosition, Quaternion projectileRotation){

		Quaternion targetAngle = projectileRotation;
		if(Aims){
			targetAngle = Quaternion.Euler (0, 0, AngleBetweenVector2(FirePoint.position, player.transform.position));
		}
		//float targetAngle = AngleBetweenVector2(DarkBowArm.position, player.transform.position) + (isFlipped? 10 : -10);

		 if(Projectile == null){
			GameObject obj = poolYard.pool_Projectile_Enemy.GetPoolObject();
			if(obj == null) return;
			obj.transform.position = projectilePosition;
			obj.transform.rotation = targetAngle;
			obj.SetActive(true);
		}else{
			Instantiate(Projectile, projectilePosition, projectileRotation);
		}
	}


	private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
 	{
         Vector2 diference = vec2 - vec1;
         float sign = (vec2.y < vec1.y)? -1.0f : 1.0f;
         return Vector2.Angle(Vector2.right, diference) * sign;
    }	
}

public enum FireRateType{
	Single,
	Burst
}

public enum SpreadFireType{
	None,
	Angled,
	Straight
}