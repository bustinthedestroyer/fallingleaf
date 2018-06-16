using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolYard : MonoBehaviour {
    
    public PoolController pool_Explosion;
    public PoolController pool_Projectile_Enemy;
    public PoolController pool_Projectile_Player;
    public PoolController pool_Projectile_Player_Special;

    public PoolController pool_Minion;
    public PoolController pool_Fighter;
    public PoolController pool_Hero;
    public PoolController pool_Champion;
    public PoolController pool_Boss;

    
    public PoolController pool_item_Potion;
    public PoolController pool_item_Page;
    public PoolController pool_item_Special;
    public PoolController pool_item_Attack;
    public PoolController pool_item_Coin;

    void Start(){
        
    }

    public void ResetPools(){
        pool_Explosion.Reset();
        pool_Projectile_Enemy.Reset();
        pool_Projectile_Player.Reset();
        pool_Projectile_Player_Special.Reset();
        pool_Minion.Reset();
        pool_Hero.Reset();
        pool_Champion.Reset();
        pool_Boss.Reset();
        pool_item_Potion.Reset();
        pool_item_Page.Reset();
        pool_item_Special.Reset();
        pool_item_Attack.Reset();
        pool_item_Coin.Reset();
        pool_Fighter.Reset();
    }
}
