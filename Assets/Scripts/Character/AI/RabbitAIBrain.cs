using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RabbitAIBrain : AIBrain {

    protected override void Start()
    {
		base.Start();

		m_bIsActive = true;
		m_strCAction = "Spawned";
		m_Target = GameObject.Find("Player");
	}
	
	protected override void Update()
	{
		base.Update();

		if(m_bIsActive)
        {
            switch (m_CState)
            {
                case State.IDLE:
                {
                    m_strCAction = "Entering Idle";
                    IdleState();
                    break;
                }
                case State.WANDER:
                {
                    m_strCAction = "Entering Wander";
                    WanderState();
                    break;
                }
                case State.COMBAT:
                {
                    m_strCAction = "Entering Combat";
                    CombatState();
                    break;
                }
                case State.DEAD:
                {
                    m_strCAction = "Entering Dead";
                    DeadState();
                    break;
                }
            }
        }
        else
        {

        }
    }

    void IdleState()
    {
        if(m_nIdleTime>m_nIdleTimer)
        {
            m_CState = State.WANDER;
            //m_CWaypoints.Add(new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
            m_nIdleTime = 0.0f;
        }
        else 
        {
            m_nIdleTime += Time.deltaTime;
        }
    }

    void WanderState()
    {
        if(m_CCurrentWaypoint < m_CWaypoints.Count)
        {
			//Get distance to waypoint
				//If waypoint is within distance, go to next waypoint
				//Else
					//Get direction to waypoint
					//Move in direction
					//If colliding with obstacle and not at waypoint
						//Jump

            Vector3 target = m_CWaypoints[m_CCurrentWaypoint].position;     
            Vector3 distance = target - transform.position;

			//If close enough to the waypoint, go to the next one
			if(distance.magnitude < 0.4f)
            {
                transform.position = target;
                ++m_CCurrentWaypoint;
            }
            else
            {
				//[Matt] This will need to be smoother
                transform.LookAt(target);

				Vector2 direction = new Vector2(distance.x, distance.z) * m_nSpeed;
				m_characterBehavior.SetVelocity(ref direction);
            }
        }
        else
        {
            m_CState = State.IDLE;
            m_CCurrentWaypoint = 0;
        }
        CheckTargetDistance();
    }

    void CombatState()
    {
        Vector3 target = m_Target.transform.position;

		//[Matt] This will need to be smoother
        //transform.LookAt(target);

		Vector3 distance = target - transform.position;
		Vector2 distance2D = new Vector2(distance.x, distance.z);

		Vector2 direction = (distance2D.sqrMagnitude > 2.0f) ? distance2D * m_nSpeed : Vector2.zero;
		//m_characterBehavior.SetVelocity(ref direction);

        CheckTargetDistance();
    }

    void DeadState()
    {
    }

    void CheckTargetDistance()
    {
        if(Vector2.Distance(m_Target.transform.position, gameObject.transform.position) <= 10)
        {
            m_CState = State.COMBAT;
        }
        else
        {
            m_CState = State.WANDER;
        }
    }

    [Header("Rabbit Specific Properties")]
    public GameObject m_Target;
    public List<string> m_CSkills;

}
