using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RabbitAI : BaseCharacter {

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_bIsActive = true;
        m_nCHealth = 10000;
        m_nSpeed = 5;
        m_strCName = "Mr. Rabbit Squad";
        m_strCAction = "Spawned";
        m_strCreatureType = "Rabbit";
        m_CState = State.IDLE;
        m_CCharacterController = gameObject.GetComponent<CharacterController>();
        m_nIdleTime = 0.0f;
        m_nIdleTimer = 5.0f;
        m_nGravity = 1000.0f;
        m_CNavMesh = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(m_bIsActive)
        {
            m_strCAction = "Is Active";
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
        m_strCAction = "Wandering";
        if(m_CCurrentWaypoint < m_CWaypoints.Count)
        {
            m_strCAction = "Set Wandering Target";
            Vector3 target = m_CWaypoints[m_CCurrentWaypoint].position; ;
            m_strCAction = "Keeping Target at Character Height";
            target.y = transform.position.y;
            m_strCAction = "Set Movement Direction";
            Vector3 moveDirection = target - transform.position;
            m_strCAction = "Moving";
            if(moveDirection.magnitude < 0.4f)
            {
                m_strCAction = "Forced Movement";
                transform.position = target;
                m_CCurrentWaypoint++;
            }
            else
            {
                m_strCAction = "Smooth Movement";
                transform.LookAt(target);
                moveDirection.y -= m_nGravity * Time.deltaTime;
                m_CCharacterController.Move(moveDirection.normalized * m_nSpeed * Time.deltaTime);
            }
            m_strCAction = "Movement Complete";
        }
        else
        {
            m_CState = State.IDLE;
            m_CCurrentWaypoint = 0;
            m_strCAction = "Current Waypoint Reset";
        }
    }

    void CombatState()
    {

    }

    void DeadState()
    {
    }

    [Header("Rabbit Specific Properties")]
    public GameObject m_Target;
    public List<string> m_CSkills;

}
