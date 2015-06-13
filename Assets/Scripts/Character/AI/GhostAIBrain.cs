using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostAIBrain : AIBrain
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        CheckHealth();
    }

	protected override void IdleState()
    {
		base.IdleState();
    }

	protected override void WanderState()
    {
		base.WanderState();
    }

	protected override void CombatState()
    {
		base.CombatState();
    }

	protected override void DeadState()
    {
		base.DeadState();
    }

    void CheckHealth()
    {
        if(m_health < 1)
        {
            SetState(State.DEAD);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DirtyWay")
        {
            Debug.Log("Touched by:" + other.gameObject.name);
            PlayHit();
        }
    }

    void PlayHit()
    {
        m_CState = State.DEAD;
    }


    [Header("Ghost Specific Properties")]
    public GameObject m_Target;

}
