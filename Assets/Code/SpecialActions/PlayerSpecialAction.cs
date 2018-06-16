using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAction : MonoBehaviour {
	public string ActionName;
	public int ActionResourceCost;
	public Action ActionExecute;
	public Player playerController;
	public float ActionDuration;
}