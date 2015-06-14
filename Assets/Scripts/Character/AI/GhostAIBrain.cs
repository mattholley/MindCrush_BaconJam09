using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostAIBrain : AIBrain
{

    protected override void Start()
    {
        base.Start();

        Debug.Log(health);
        health = 20.0f;
    }

    protected override void Update()
    {
        base.Update();
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
        Debug.Log(health);
		GameObject deathEffectObject = GameObject.Instantiate(m_deathEffect);
		if(deathEffectObject)
		{
			deathEffectObject.transform.position = transform.position;
		}

        base.DeadState();
    }

    [Header("Ghost Specific Properties")]
	public GameObject m_deathEffect;
}