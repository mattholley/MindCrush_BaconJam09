using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIBrain : MonoBehaviour 
{
	public enum State
	{
		IDLE,
		WANDER,
		PURSUE,
		COMBAT,
		DEAD
	}

	// Use this for initialization
	protected virtual void Start () 
	{
		m_characterBehavior = GetComponent<CharacterBehavior>();

		m_isActive = true;
		m_action = "Spawned";
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
		if(m_isActive)
		{
			switch (m_state)
			{
				case State.IDLE:
				{
					IdleState();
					break;
				}
				case State.WANDER:
				{
					WanderState();
					break;
				}
				case State.COMBAT:
				{
					CombatState();
					break;
				}
				case State.DEAD:
				{
					DeadState();
					break;
				}
				case State.PURSUE:
				{
					PursueState();
					break;
				}
			}
		}
	}

	protected virtual void SetState(State newState)
	{
		if(m_state != newState)
		{
			m_action = "Entering " + newState.ToString();
			m_state = newState;
		}
	}

	protected virtual void IdleState()
	{
		m_idleTime += Time.deltaTime;
		if(m_idleTime >= m_idleTimeMax)
		{
			SetState (State.WANDER);
			m_idleTime = 0.0f;
		}
	}
	
	protected virtual void WanderState()
	{
		if(m_currentWaypointIndex < m_waypoints.Count)
		{
			//Get distance to waypoint
			//If waypoint is within distance, go to next waypoint
			//Else
			//Get direction to waypoint
			//Move in direction
			//If colliding with obstacle and not at waypoint
			//Jump
			
			Vector3 target = m_waypoints[m_currentWaypointIndex].position;     
			Vector3 distance = target - transform.position;
			
			//If close enough to the waypoint, go to the next one
			if(distance.magnitude < 2.0f)
			{
				transform.position = target;
				++m_currentWaypointIndex;
			}
			else
			{
				Vector2 direction = new Vector2(distance.x, distance.z).normalized;
				m_characterBehavior.SetVelocity(ref direction);
			}
		}
		else
		{
			SetState(State.IDLE);
			m_currentWaypointIndex = 0;
		}
	}
	
	protected virtual void CombatState()
	{
		Vector3 target = m_target.transform.position;
		
		Vector3 distance = target - transform.position;
		Vector2 distance2D = new Vector2(distance.x, distance.z);
		
		if(distance.sqrMagnitude >= 100.0f)
		{
			SetState(State.PURSUE);
			return;
		}
		
		Vector2 direction = distance2D.normalized;
		
		m_characterBehavior.Jump(1.0f);
		m_characterBehavior.SetVelocity(ref direction);
	}
	
	protected virtual void DeadState()
	{
		Destroy(gameObject);
	}

	protected virtual void PursueState()
	{
		Vector3 target = m_target.transform.position;
		
		Vector3 distance = target - transform.position;
		Vector2 distance2D = new Vector2(distance.x, distance.z);
		
		if(distance.sqrMagnitude < 100.0f)
		{
			SetState(State.COMBAT);
			return;
		}
		
		Vector2 direction = distance2D.normalized;
		m_characterBehavior.SetVelocity(ref direction);
	}

	public void ProcessSensorResult(ref SensorResult result)
	{
		if(m_target)
		{
			if(result.enter == false && result.obj == m_target && result.sensor.GetType() == typeof(AwarenessSensor))
			{
				m_target = null;
				SetState(State.IDLE);
			}
		}
		else
		{
			if(result.obj.tag == "Player")
			{
				m_target = result.obj;
				SetState(State.PURSUE);
			}
		}
	}
	
	protected CharacterBehavior m_characterBehavior;
	protected GameObject m_target;
	private GameObject m_sensors;

	private float m_health;

	//[Matt] May need to move/remove some of this
	[Header("Character Base Stats")]
	public bool m_isActive = true;
	public float health { get { return m_health; } set { m_health = value; if(m_health <= 0.0f) { SetState (State.DEAD); } } }
	public string m_sname;
	public string m_action;
	public string m_creatureType;

	private State m_state = State.IDLE;
	public int state { get { return (int)m_state; } }

	[Header("AI Specific Properties")]
	public List<Transform> m_waypoints;
	public int m_currentWaypointIndex = 0;
	public float m_idleTimeMax = 5.0f;
	public float m_idleTime = 0.0f;
}
