using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

	public Vector2 StartPosition;
	public Vector2 EndPosition;
	public float TransitionTime;

	public GameObject TransitionGraphic;
	
	void Start () {
		//StartTransition();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MoveDragon()
	{
		Vector2 StartingPosition = TransitionGraphic.transform.position;

		float elapsedTime = 0;

		while(elapsedTime < TransitionTime){

			var theTime = (elapsedTime/TransitionTime);

			////Move up or down
			TransitionGraphic.transform.position = Vector2.Lerp(StartingPosition, EndPosition, theTime);
			elapsedTime += Time.deltaTime;

			yield return null;
		}
		TransitionGraphic.transform.position = StartPosition;

	}

	public void StartTransition(){
		StartCoroutine(MoveDragon());
	}
}
