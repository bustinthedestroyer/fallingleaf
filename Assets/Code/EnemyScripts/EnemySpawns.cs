using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour {

	public Vector2 UpperLeftHandCorner;
	public Vector2 UpperRightHandCorner;
	public Vector2 BottomLeftHandCorner;
	public Vector2 BottomRightHandCorner;

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		DrawCross(UpperLeftHandCorner);
		DrawCross(UpperRightHandCorner);
		DrawCross(BottomLeftHandCorner);
		DrawCross(BottomRightHandCorner);
	}

	void DrawCross(Vector2 here){
		float size = .3f;
		Gizmos.DrawLine(here - Vector2.up * size, here + Vector2.up * size);
		Gizmos.DrawLine(here - Vector2.left * size, here + Vector2.left * size);
	}

	public Vector2 GetRandomTop(){
		var y = UpperLeftHandCorner.y;
		var x = Random.Range(UpperLeftHandCorner.x, UpperRightHandCorner.x);
		return new Vector2(x,y);
	}
}