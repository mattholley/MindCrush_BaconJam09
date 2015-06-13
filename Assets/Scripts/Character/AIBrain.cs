using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIBrain : MonoBehaviour 
{

	// Use this for initialization
	protected virtual void Start () 
	{
		m_characterBehavior = GetComponent<CharacterBehavior>();
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
	
	}

	protected CharacterBehavior m_characterBehavior;

	//[Matt] May need to move/remove some of this
	[Header("Character Base Stats")]
	public bool m_bIsActive;
	public float m_nCHealth;
	public float m_nSpeed;
	public string m_strCName;
	public string m_strCAction;
	public string m_strCreatureType;
	public enum State
	{
		WANDER, COMBAT, IDLE, DEAD
	}
	public State m_CState = State.IDLE;
	
	[Header("AI Specific Properties")]
	public List<Transform> m_CWaypoints;
	public int m_CCurrentWaypoint;
	public float m_nIdleTimer;
	public float m_nIdleTime;
}
