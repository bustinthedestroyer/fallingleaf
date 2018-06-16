using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {

	public float m_XScale = 1;
	public float m_YScale = 1;
	public float flySpeed;
	public float patrolSpeed;

	private Vector3 m_Pivot;
	private Vector3 m_PivotOffset;
	private float m_Phase;
	private bool m_Invert = false;
	private float m_2PI = Mathf.PI * 2;
	private Vector2 startPosition = new Vector2(0,7);
	private Vector2 destination = new Vector2(0,3.5f);
	bool patrol = false;
	private Transform myTransform;

	public Health health;

	void Awake(){
		myTransform = transform;
	}
	
	void Update () {
		if(patrol){
			Partrol();
		}else{
			myTransform.position = Vector2.MoveTowards(myTransform.position, destination, flySpeed * Time.deltaTime);
			if((Vector2)myTransform.position == destination){
				m_Pivot = destination;
				Invoke("startPatrol",1f);
			}
		}
	}

	public void startPatrol(){
		
		health.Invincible = false;
		patrol = true;
	}

	void Partrol(){
		m_PivotOffset = Vector3.up * 2 * m_YScale;
	
		m_Phase += patrolSpeed * Time.deltaTime;
		if(m_Phase > m_2PI)
		{
			m_Invert = !m_Invert;
			m_Phase -= m_2PI;
		}
		if(m_Phase < 0) m_Phase += m_2PI;
	
		myTransform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
		var positionx = Mathf.Sin(m_Phase) * m_XScale;
		var positiony = Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_YScale;
		myTransform.position = new Vector2(myTransform.position.x + positionx, myTransform.position.y + positiony);
	}
	
	void OnEnable(){
		myTransform.position = startPosition;
		health.Invincible = true;
	}

	void OnDisable(){
		patrol = false;
	}
}
