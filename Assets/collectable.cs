using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour {

	public itemType ItemType;
	
	public void Collect() {
		Debug.Log(ItemType.ToString() + ", collected!");

		switch(ItemType){
			
			case itemType.Potion:
				////Gain Health
			break;
			
			case itemType.Special:
				////Special Attack
			break;
			
			case itemType.Attack:
				////Special Attack Level Up
			break;
			
			case itemType.Page:
				////Increase Pages
			break;
			
			case itemType.Coin:
				////Increase Pages
			break;

			default:
			break;
		}

	}
}

public enum itemType
{
	Potion,
	Special,
	Attack,
	Page,
	Coin
}