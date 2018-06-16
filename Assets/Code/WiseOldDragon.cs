using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiseOldDragon : MonoBehaviour {

	public Text SpeechText;
	public SpriteRenderer DragonHeadSprite;
	public CanvasGroup SpeechPanel;
	public Vector2 SpeechPosition;
	public Vector2 StartPosition;

	public Button ResponseButton;

	void Start(){
		SpeechPanel.alpha = 0;
		DragonHeadSprite.color = new Color(1f,1f,1f,0);
        StartCoroutine(MoveDragon(true, .25f, 1));
	}

	public void GetFeedBack(){
		SpeechText.text = "I was young once too.";
		ResponseButton.gameObject.SetActive(false);
        StartCoroutine(MoveDragon(false, 2f, 1));
	}
	
    IEnumerator MoveDragon(bool FadeIn, float time, float startDelay = 0)
	{
		Vector2 StartingPosition = transform.position;
		var newPosition = FadeIn ? SpeechPosition : StartPosition;

		float elapsedTime = 0;

		yield return new WaitForSeconds(startDelay);

		while(elapsedTime < time){

			var theTime = (elapsedTime/time);
			
			////Fade in or out
			var q = Mathf.SmoothStep(FadeIn ? 0:1, FadeIn? 1:0, theTime);
			DragonHeadSprite.color = new Color(1f,1f,1f,q);
			SpeechPanel.alpha = (q);

			////Move up or down
			transform.position = Vector2.Lerp(StartingPosition, newPosition, theTime);
			elapsedTime += Time.deltaTime;

			yield return null;
		}
	}

}
