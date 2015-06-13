using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RabbitAIBrain : AIBrain {

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

	protected override void PursueState()
	{
		base.PursueState();
	}

	public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DirtyWay")
        {
            Debug.Log("Touched by:" + other.gameObject.name);
        }
    }

    [Header("Rabbit Specific Properties")]
    public List<string> m_skills;

}
