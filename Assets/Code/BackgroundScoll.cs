using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoll : MonoBehaviour {

	public float scrollSpeed;
	private Vector2 savedOffset;
	private Renderer renderer;
	public float nextX;
	private float currentX;
	private float previousY = 0.0f;

	void Start(){
		renderer = GetComponent<Renderer>();
		savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
		currentX = nextX;
	}

	float scrollTime = 0;

	void Update () {
		float y = Mathf.Repeat(scrollTime * scrollSpeed, 1);
		//Debug.Log("y:"+y);
		scrollTime += Time.smoothDeltaTime;
		if(nextX != currentX){
			if(y > .5f && previousY < .5f){
				currentX = nextX;
				y=0;
				scrollTime=0;
				StageTransitioning = false;
			}
		}
		Vector2 offset = new Vector2(currentX, y);
		renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
		previousY = y;
	}

	IEnumerator ChangeSpeed(float nextScrollSpeed, float transitionTime){

		StageSpeedTransitioning = true;
		float previousScrollSpeed = scrollSpeed;
		float elapsedTime = 0;
		
		// float slowSpeed;
		// float fastSpeed;
		// if(nextScrollSpeed > previousScrollSpeed){
		// 	slowSpeed = previousScrollSpeed;
		// 	fastSpeed = nextScrollSpeed;
		// }else{
		// 	slowSpeed = nextScrollSpeed;
		// 	fastSpeed = previousScrollSpeed;
		// }
		
		while(elapsedTime < transitionTime){

			var theTime = (elapsedTime/transitionTime);
			
			//scrollSpeed = Mathf.Lerp(nextScrollSpeed, previousScrollSpeed, theTime);
			scrollSpeed = Mathf.Lerp(previousScrollSpeed, nextScrollSpeed, theTime);

			//scrollSpeed = Mathf.Abs(Mathf.Lerp(previousScrollSpeed, nextScrollSpeed, theTime));
			//Debug.Log(scrollSpeed);
			//scrollSpeed = Mathf.Lerp(slowSpeed, fastSpeed, theTime);
			//scrollSpeed = Mathf.SmoothStep(slowSpeed, fastSpeed, theTime);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		//scrollSpeed = nextScrollSpeed;

		StageSpeedTransitioning = false;
	}

	void OnDisable(){
		renderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
	}

	public void ChangeColumn(float newColumn){
		StageTransitioning = true;
		nextX = newColumn;
	}
	
	public void ChangeScrollSpeed(float newScrollSpeed){
		StartCoroutine(ChangeSpeed(newScrollSpeed, 3));
	}

	public bool StageSpeedTransitioning = false;
	public bool StageTransitioning = false;
}