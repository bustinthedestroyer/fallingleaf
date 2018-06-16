using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenManager {

	public static float Top = 5;
	public static float Bottom = -5;
	public static float Left = -2.8f;
	public static float Right = 2.8f;

	// void OnDrawGizmos() {
	// 	Gizmos.color = Color.red;
	// 	DrawCross(new Vector2(0, Top));
	// 	DrawCross(new Vector2(0, Bottom));
	// 	DrawCross(new Vector2(Left,0));
	// 	DrawCross(new Vector2(Right,0));
	// }

	// void DrawCross(Vector2 here){
	// 	float size = .3f;
	// 	Gizmos.DrawLine(here - Vector2.up * size, here + Vector2.up * size);
	// 	Gizmos.DrawLine(here - Vector2.left * size, here + Vector2.left * size);
	// }

	public static bool IsOnScreen(Vector2 transformPosition){
		
		return 
			transformPosition.x > Left && transformPosition.x < Right && 
			transformPosition.y > Bottom && transformPosition.y < Top;
		;
	}
}