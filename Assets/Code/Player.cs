using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private bool PlayerMoving = false;
    public bool ForceMoving = false;
    public float xClampMin, xClampMax, yClampMin, yClampMax;
    public Transform FirePoint;
    private float fireNext = 0;
    private List<Action> Attacks, Specials;
    public int selectedWeaponIndex = 0;
    public GameController gameController;

    public Slider PlayerHealthSlider, PlayerResourceSlider, PlayerExperianceSlider;
    public int PlayerHealthMax, PlayerResourceMax, PlayerExperianceMax;
    public int PlayerHealthCurrent, PlayerResourceCurrent;
    public Collider2D MovePad;
    public float screenTouchSpeed;
    public Vector2 StartPosition, NextPosition;
    private bool UseSpecialAttack = false;
    public PlayerSpecialAction SelectedSpecialAttack;
    public bool IsSpecialActioning = false;
    public bool ControlEnabled = false;
    // public PoolController explosionPool;
    // public PoolController playerProjectilePool;
    public PauseMenuController pauseMenuController;

    public PoolYard poolYard;

    Transform myTransform;

    void Awake(){
        myTransform = transform;
        LoadAttacks();
        LoadSpecials();
    }


    void Start()
    {
    }

	void Update () {
        UpdatePlayer();
	}

    public void MovePlayerTo(Vector2 playerNextPosition){
        NextPosition = playerNextPosition;
        ControlEnabled = false;
        PlayerMoving = false;
        ForceMoving = true;
    }

	void UpdatePlayer(){

        if(ControlEnabled){
            if (Input.GetButtonDown("Fire1"))
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(MovePad.OverlapPoint(touchPosition)){
                    pauseMenuController.StartPause(false);
                    PlayerMoving=true;
                }
            }
            if (PlayerMoving)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var nextPosition = new Vector2(touchPosition.x, touchPosition.y + 1f);            
                myTransform.position = Vector2.MoveTowards(myTransform.position, nextPosition, screenTouchSpeed * Time.deltaTime);
                myTransform.position = new Vector2(
                    Mathf.Clamp(myTransform.position.x, xClampMin, xClampMax)
                    ,Mathf.Clamp(myTransform.position.y, yClampMin, yClampMax)
                );
                // if(UseSpecialAttack){
                //     //SelectedSpecialAttack.ActionExecute();
                //     //fireNext += SelectedSpecialAttack.ActionDuration;
                //     //GainResouce(-SelectedSpecialAttack.ActionResourceCost);                    
                //     //IsSpecialActioning = true;
                //     //UseSpecialAttack = false;
                //     Specials[0].Invoke();
                // }
                if (Time.time > fireNext)
                {
                    Attack();
                }
            }
            if (Input.GetButtonUp("Fire1") && PlayerMoving)
            {
                PlayerMoving = false;
                pauseMenuController.StartPause(true);
            }
        }

        if(ForceMoving){
            if((Vector2)myTransform.position != NextPosition){
                myTransform.position = Vector2.MoveTowards(myTransform.position, NextPosition, 3 * Time.deltaTime);
            }else{
                ControlEnabled = true;
                ForceMoving = false;
            }
        }


       

    }

    public void Attack(){
        if(IsSpecialActioning)
        {
            Specials[0].Invoke();
        }else{
            Attacks[playerLevel-1].Invoke();
        }
    }

    // public void SelectSpecialAttack(PlayerSpecialAction specialAction){
    //     SelectedSpecialAttack = specialAction;
    //     UseSpecialAttack = true;
    // }

    // public void SelectWeapon(int weaponIndex){
    //     selectedWeaponIndex = weaponIndex;
    // }

    public void SpecialAttack(){
        if(!IsSpecialActioning){
            IsSpecialActioning = true;
            Invoke("RegularAttack", 5);
        }
    }

    public void RegularAttack(){
        
        IsSpecialActioning = false;
    }
    
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "ProjectileEnemy")
		{
            
			GameObject explosion = poolYard.pool_Explosion.GetPoolObject();
			explosion.transform.position = collider.transform.position;
			explosion.transform.rotation = collider.transform.rotation;
			explosion.SetActive(true);

            collider.gameObject.SetActive(false);
            GainHealth(-1);
		}
        
		if(collider.tag == "Collectable")
		{
            CollectItem(collider.GetComponent<collectable>());
            collider.gameObject.SetActive(false);
		}

		if(collider.tag == "Enemy")
		{
			GameObject explosion = poolYard.pool_Explosion.GetPoolObject();
			explosion.transform.position = collider.transform.position;
			explosion.transform.rotation = collider.transform.rotation;
			explosion.SetActive(true);
            GainHealth(-1);
		}
	}

    void CollectItem(collectable itemToCollect){
        switch(itemToCollect.ItemType){	

			case itemType.Potion:
                GainHealth(3);
			break;

			case itemType.Special:
				SpecialAttack();
			break;
			
			case itemType.Attack:
				GainWeaponLevel();
			break;
			
			case itemType.Page:
				GainPages(1);
			break;
			
			case itemType.Coin:
				GainCoins(1);
			break;

			default:
			break;
		}
    }

    public int PageCount;

    void OnDisable(){
        
    }

    public void Reset(){
        myTransform.position = StartPosition;
        PlayerMoving = false;
        ControlEnabled = false;
        //playerLevel = 1;

        PlayerHealthCurrent = PlayerHealthMax;
        PlayerHealthSlider.maxValue = PlayerHealthMax;
        PlayerHealthSlider.value = PlayerHealthCurrent;
        
        // PlayerResourceCurrent = 0;
        // PlayerResourceSlider.maxValue = PlayerResourceMax;
        // PlayerResourceSlider.value = PlayerResourceCurrent;
        
        playerLevel = 1;

        gameController.textCoins.text = "$ " +coins.ToString();
        //gameController.textPages.text = pages + "/" + pagesMax;
        gameController.textPages.text = pages + " x ";
        gameController.textAttack.text = playerLevel + "/" + playerLevelMax;
        
    }
    
    void LoadSpecials(){
        Specials = new List<Action>();

        Specials.Add(()=>
        {            
            GameObject obj = poolYard.pool_Projectile_Player_Special.GetPoolObject();
            if(obj == null) return;
            obj.transform.position = FirePoint.position;
            obj.transform.rotation = FirePoint.rotation;
            obj.SetActive(true);
            fireNext = Time.time + 0.1f;
        });
    }


    void LoadAttacks(){
        Attacks = new List<Action>();

        Attacks.Add(()=>
        {
            FireProjectile(FirePoint.position, FirePoint.rotation);
            fireNext = Time.time + 0.40f;
        });
        Attacks.Add(()=>
        {
            FireProjectile(FirePoint.position, FirePoint.rotation);
            fireNext = Time.time + 0.35f;
        });
        Attacks.Add(()=>
        {
            var position1 = new Vector2(FirePoint.position.x + .1f, FirePoint.position.y);
            var position2 = new Vector2(FirePoint.position.x - .1f, FirePoint.position.y);
            FireProjectile(position1, FirePoint.rotation);
            FireProjectile(position2, FirePoint.rotation);
            fireNext = Time.time + 0.35f;
        });
        Attacks.Add(()=>
        {
            var position1 = new Vector2(FirePoint.position.x + .1f, FirePoint.position.y);
            var position2 = new Vector2(FirePoint.position.x - .1f, FirePoint.position.y);
            FireProjectile(position1, FirePoint.rotation);
            FireProjectile(position2, FirePoint.rotation);
            fireNext = Time.time + 0.3f;
        });
        Attacks.Add(()=>
        {
            var spread1 = Quaternion.Euler(0,0, 95);
            var spread2 = Quaternion.Euler(0,0, 85);
            FireProjectile(FirePoint.position, spread1);
            FireProjectile(FirePoint.position, spread2);
            FireProjectile(FirePoint.position, FirePoint.rotation);
            fireNext = Time.time + 0.3f;
        });
        Attacks.Add(()=>
        {
            var spread1 = Quaternion.Euler(0,0, 95);
            var spread2 = Quaternion.Euler(0,0, 85);
            FireProjectile(FirePoint.position, spread1);
            FireProjectile(FirePoint.position, spread2);
            FireProjectile(FirePoint.position, FirePoint.rotation);
            fireNext = Time.time + 0.25f;
        });
        Attacks.Add(()=>
        {
            var position1 = new Vector2(FirePoint.position.x - .3f, FirePoint.position.y);
            var position2 = new Vector2(FirePoint.position.x - .1f, FirePoint.position.y);
            var position3 = new Vector2(FirePoint.position.x + .1f, FirePoint.position.y);
            var position4 = new Vector2(FirePoint.position.x + .3f, FirePoint.position.y);
            FireProjectile(position1, FirePoint.rotation);
            FireProjectile(position2, FirePoint.rotation);
            FireProjectile(position3, FirePoint.rotation);
            FireProjectile(position4, FirePoint.rotation);
            fireNext = Time.time + 0.25f;
        });
        Attacks.Add(()=>
        {
            var position1 = new Vector2(FirePoint.position.x - .3f, FirePoint.position.y);
            var position2 = new Vector2(FirePoint.position.x - .1f, FirePoint.position.y);
            var position3 = new Vector2(FirePoint.position.x + .1f, FirePoint.position.y);
            var position4 = new Vector2(FirePoint.position.x + .3f, FirePoint.position.y);
            FireProjectile(position1, FirePoint.rotation);
            FireProjectile(position2, FirePoint.rotation);
            FireProjectile(position3, FirePoint.rotation);
            FireProjectile(position4, FirePoint.rotation);
            fireNext = Time.time + 0.2f;
        });
        Attacks.Add(()=>
        {
            var spread1 = Quaternion.Euler(0,0, 100);
            var spread2 = Quaternion.Euler(0,0, 95);
            var spread3 = Quaternion.Euler(0,0, 85);
            var spread4 = Quaternion.Euler(0,0, 80);
            FireProjectile(FirePoint.position, spread1);
            FireProjectile(FirePoint.position, spread2);
            FireProjectile(FirePoint.position, spread3);
            FireProjectile(FirePoint.position, spread4);
            FireProjectile(FirePoint.position, FirePoint.rotation);
            fireNext = Time.time + 0.2f;
        });
        Attacks.Add(()=>
        {
            var spread1 = Quaternion.Euler(0,0, 100);
            var spread2 = Quaternion.Euler(0,0, 95);
            var spread3 = Quaternion.Euler(0,0, 85);
            var spread4 = Quaternion.Euler(0,0, 80);
            FireProjectile(FirePoint.position, spread1);
            FireProjectile(FirePoint.position, spread2);
            FireProjectile(FirePoint.position, spread3);
            FireProjectile(FirePoint.position, spread4);
            FireProjectile(FirePoint.position, FirePoint.rotation);
            fireNext = Time.time + 0.15f;
        });
    }

    public void FireProjectile(Vector2 projectilePosition, Quaternion projectileRotation){
        GameObject obj = poolYard.pool_Projectile_Player.GetPoolObject();
        if(obj == null) return;
        obj.transform.position = projectilePosition;
        obj.transform.rotation = projectileRotation;
        obj.SetActive(true);
	}

#region player stats


    void OnEnable(){
        
        Reset();
    }
    
    
    // public int playerLevel = 1;
    // private int playerLevelMax = 5;
    // private int playerExperience = 0;
    // private int experienceLevelFactor = 10;
    // private int experienceNextLevel = 0;

    // public void GainExperiance(int experianceToGain){

    //     if(playerLevel < playerLevelMax){
    //         ////Gain Experience
    //         playerExperience += experianceToGain;
    //         PlayerExperianceSlider.value = playerExperience;
            
    //         ////Did we level up?
    //         if(playerExperience >= experienceNextLevel){
    //             PlayerExperianceSlider.minValue = experienceNextLevel;
    //             playerLevel++;
    //             gameController.UpdateTitleText("level++", .5f);
    //             experienceNextLevel = experienceNextLevel + playerLevel * experienceLevelFactor;
    //             PlayerExperianceSlider.maxValue = experienceNextLevel;
    //         }
    //     }
    // }


    public int playerLevel = 1;
    
    public int playerLevelMax = 10;
    public void GainWeaponLevel(){
        playerLevel++;
        if(playerLevel > playerLevelMax){
            playerLevel = playerLevelMax;
        }
        gameController.textAttack.text = playerLevel + "/" + playerLevelMax;
    }

    public void GainResouce(int resourceToGain){


        PlayerResourceCurrent += resourceToGain;
        PlayerResourceCurrent = Mathf.Clamp(PlayerResourceCurrent, 0, PlayerResourceMax);
        PlayerResourceSlider.value = PlayerResourceCurrent;

        // if(PlayerResourceCurrent <= PlayerResourceMax){
        //     PlayerResourceCurrent += resourceToGain;
        //     PlayerResourceCurrent = PlayerResourceCurrent > PlayerResourceMax ? PlayerResourceMax : PlayerResourceCurrent;
        //     PlayerResourceSlider.value = PlayerResourceCurrent;
        // }
    }

    public void GainHealth(int healthToGain){
        
        PlayerHealthCurrent += healthToGain;
    
        if(PlayerHealthCurrent > PlayerHealthMax){
            PlayerHealthCurrent = PlayerHealthMax;
        }
        
        if(PlayerHealthCurrent <= 0){
            gameController.PlayerHasDied();
        }
        
        PlayerHealthSlider.value = PlayerHealthCurrent;
        //Debug.Log(PlayerHealthCurrent);
    }

    int coins = 0;

    public void GainCoins(int coinsToGain){
        coins += coinsToGain;
        gameController.textCoins.text = ": " +coins.ToString();
    }
    int pages = 0;
    //public int pagesMax = 0;
    public void GainPages(int pagesToGain){
        pages += pagesToGain;

        // if(pages > pagesMax){
        //     pages = pagesMax;
        // }
        //gameController.textPages.text = pages + "/" + pagesMax;
        gameController.textPages.text = pages + " x ";
    }

    public void TotalScore(){
        
        ControlEnabled = false;
        
        gameController.textCoinsTotal.text = "$" +coins.ToString();
        //gameController.textPagesTotal.text = pages + " / " + pagesMax;
        gameController.textPagesTotal.text = " x " + pages;
        gameController.textAttackTotal.text = playerLevel + " / " + playerLevelMax;
    }

    

#endregion



#region TouchPad Controls

//  if (Input.GetButtonDown("Fire1"))
//         {
            
//             Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             if(MovePad.OverlapPoint(touchPosition)){
                
//                 gameController.PauseGame(false);
                
//                 moving=true;
//                 PadPosition = touchPosition;
//                 joyPad = Instantiate(JoyPad, PadPosition, transform.rotation);
//                 joyStick = Instantiate(JoyStick, PadPosition, transform.rotation);
//             }
//         }

//         if (moving)
//         {
//             Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             Vector2 offset = touchPosition - joyPad.transform.position;
//             joyStick.transform.position = joyPad.transform.position + Vector3.ClampMagnitude(offset, .5f);

//             ////Distance sensative movement
//             // Gets a vector that points from the player's position to the target's.
//             var heading = joyStick.transform.position - joyPad.transform.position;
//             //Debug.Log(heading.magnitude);
//             if(heading.magnitude > minimumStickDistance)
//             {
//                 transform.Translate(heading * DragonSpeed);        
//                 transform.position = new Vector2(
//                     Mathf.Clamp(transform.position.x, xClampMin, xClampMax)
//                     ,Mathf.Clamp(transform.position.y, yClampMin, yClampMax)
//                 );
//             }
            
//             ////normalized movement ///.05
//             // // Gets a vector that points from the player's position to the target's.
//             // var heading = joyStick.transform.position - joyPad.transform.position;
//             // //Debug.Log(heading.magnitude);
//             // if(heading.magnitude > minimumStickDistance)
//             // {
//             //     transform.Translate(heading.normalized * DragonSpeed);        
//             //     transform.position = new Vector2(
//             //         Mathf.Clamp(transform.position.x, xClampMin, xClampMax)
//             //         ,Mathf.Clamp(transform.position.y, yClampMin, yClampMax)
//             //     );
//             // }

//             if (Time.time > fireNext)
//             {
//                 Attacks[selectedWeaponIndex].Invoke();
//             }

//             if(UseSpecialAttack){
//                 SelectedSpecialAttack.ActionExecute();
//                 fireNext += SelectedSpecialAttack.ActionDuration;
//                 GainResouce(-SelectedSpecialAttack.ActionResourceCost);
//                 UseSpecialAttack = false;
//             }

//         }

//         if (Input.GetButtonUp("Fire1") && moving)
//         {
//             //moveWing(true,true);
//             moving = false;            
//             GameObject.Destroy(joyPad);
//             GameObject.Destroy(joyStick);

//             gameController.PauseGame(true);
//         }

#endregion


}
