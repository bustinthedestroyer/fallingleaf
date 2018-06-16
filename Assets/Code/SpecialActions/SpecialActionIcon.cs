using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialActionIcon : MonoBehaviour {

	public Button IconButton;

	public Player playerController;
	public PlayerSpecialAction action;
	public PauseMenuController pauseMenuController;

	void Start () {
		pauseMenuController.EventPauseGame += (bool isPaused) => { OnPause(isPaused); };
	}

	////On Pause, check for enable via resouse cost, or is special actioning.
	public void OnPause(bool Pause){
		if(Pause){
			if(!playerController.IsSpecialActioning && playerController.PlayerResourceCurrent >= action.ActionResourceCost){
				IconButton.interactable = true;
			}else{
				IconButton.interactable = false;
			}
		}else{
			IconButton.interactable = false;
		}
	}

	

// public class EventSubscriber
//         {
//             private EventThrower _Thrower;

//             public EventSubscriber()
//             {
//                 _Thrower = new EventThrower();
//                 //using lambda expression..could use method like other answers on here
//                 _Thrower.ThrowEvent += (sender, args) => { DoSomething(); };
//             }

//             private void DoSomething()
//             {
//                //Handle event.....
//             }
//         }

}