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

    [Header("Ghost Specific Properties")]
    public GameObject m_Target;

}