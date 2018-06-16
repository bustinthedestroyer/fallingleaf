using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour {
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(other.tag);

        other.gameObject.SetActive(false);
        
        // if(other.tag == "ProjectileEnemy"){
        //     other.gameObject.SetActive(false);
        // }else{
        //     Destroy(other.gameObject);
        // }
    }
}