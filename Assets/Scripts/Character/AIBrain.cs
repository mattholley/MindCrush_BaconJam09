using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIBrain : MonoBehaviour 
{
	public enum State
	{
		IDLE,
		WANDER_STEERING,
		WANDER_MOVING,
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
				case State.WANDER_STEERING:
				case State.WANDER_MOVING:
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

			if(m_target)
			{
				m_characterBehavior.m_aimTarget = m_target.transform.position;
			}
		}
	}

	protected virtual void SetState(State newState)
	{
		if(m_state != newState)
		{
			m_action = "Entering " + newState.ToString();
			m_state = newState;
			m_stateTimer = 0.0f;

		    //On State Init
		    switch(m_state)
		    {
			    case State.IDLE:
			    {
				    m_characterBehavior.Jump(0.0f);
				    m_characterBehavior.SetVelocity(Vector2.zero);
				    m_characterBehavior.SetAngularVelocity(0.0f);
				    break;
			    }
			    case State.WANDER_STEERING:
			    case State.WANDER_MOVING:
			    {

				    break;
			    }
			    case State.COMBAT:
			    {

				    break;
			    }
			    case State.DEAD:
			    {

				    break;
			    }
			    case State.PURSUE:
				{

				    break;
   			    }
            }
		}
	}

	protected virtual void IdleState()
	{
		m_stateTimer += Time.deltaTime;
		if(m_stateTimer >= m_idleTimeMax)
		{
			SetState (State.WANDER_STEERING);
			m_stateTimer = 0.0f;
		}
	}
	
	protected virtual void WanderState()
	{
		if(m_state == State.WANDER_STEERING)
		{

		}
		else
		if(m_state == State.WANDER_MOVING)
		{
			Vector3 direction = transform.forward;
			m_characterBehavior.SetVelocity(new Vector2(direction.x, direction.z));
		}
	}
	
	protected virtual void CombatState()
	{
		Vector3 target = m_target.transform.position;
		
		Vector3 distance = target - transform.position;
		if(distance.sqrMagnitude >= 100.0f)
		{
			SetState(State.PURSUE);
			return;
		}

		m_characterBehavior.Jump(1.0f);
		m_characterBehavior.SetVelocity(new Vector2(distance.x, distance.z).normalized);
	}
	
	protected virtual void DeadState()
	{
		Destroy(gameObject);
	}

	protected virtual void PursueState()
	{
		Vector3 target = m_target.transform.position;
		
		Vector3 distance = target - transform.position;
		if(distance.sqrMagnitude < 100.0f)
		{
			SetState(State.COMBAT);
			return;
		}

		m_characterBehavior.SetVelocity(new Vector2(distance.x, distance.z).normalized);
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
            Debug.Log("Here I Come");
			if(result.obj.tag == "Player")
			{
				m_target = result.obj;
				SetState(State.PURSUE);
			}
		}
	}

    public void ProcessKnockBack(GameObject source, GameObject hitObjected)
    {
        Vector3 distance = (source.transform.position - hitObjected.transform.position)*-1;
        m_characterBehavior.SetVelocity(new Vector2(distance.x, distance.z).normalized * 20); 
        SetState(State.IDLE);
        m_stateTimer = m_idleTimeMax - 1.0f;
        m_target = null;
        if (m_health <= 0.0f) { SetState(State.DEAD); } 
    }

	protected virtual void GenerateLoot() {
		if ((!m_itemDropped) && (m_dropTable.Length > 0)){
			m_itemDropped = true;
			int selectedLoot = Random.Range(0, m_dropTable.Length);
			GameObject prefab = m_dropTable[selectedLoot];
			Instantiate (prefab, transform.position,Quaternion.identity);
		}
	}

	
	protected CharacterBehavior m_characterBehavior;
	protected GameObject m_target;
	private GameObject m_sensors;

	private float m_health;

	//[Matt] May need to move/remove some of this
	[Header("Character Base Stats")]
	public bool m_isActive = true;
	public float health { get { return m_health; } set { m_health = value; } }
	public string m_sname;
	public string m_action;
	public string m_creatureType;

	private State m_state = State.IDLE;
	public int state { get { return (int)m_state; } }

	[Header("AI Specific Properties")]
	public float m_steerSpeed = 5.0f;
	public float m_idleTimeMax = 5.0f;
	public float m_wanderSteerTimeMax = 1.0f;
	public float m_wanderMoveTimeMax;
	public float m_stateTimer = 0.0f;
	public GameObject[] m_dropTable;
	public bool m_itemDropped = false;
}
