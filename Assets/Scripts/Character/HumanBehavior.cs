using UnityEngine;
using System.Collections;

public class HumanBehavior : CharacterBehavior {

	// Use this for initialization
	protected override void Start () {
		base.Start();
        m_Animator = GetComponent<Animator>();
		Transform hand = transform.FindChild("Hand");
		if(hand)
		{
			m_hand = hand.gameObject;
		}

		GameObject inventoryItemObject = GameObject.Instantiate(m_tempInventoryItemPrefab);
		if(inventoryItemObject)
		{
			inventoryItemObject.transform.SetParent(hand, false);
			
			InventoryItem inventoryItem = inventoryItemObject.GetComponent<InventoryItem>();
			Debug.Assert(inventoryItem);
			if(!inventoryItem)
			{
				Destroy(inventoryItemObject);
			}
			else
			{
				m_equippedItem = inventoryItem;
			}
		}
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
        Debug.Log(m_hand);
        m_hand.transform.LookAt(m_aimTarget);
        m_Animator.SetFloat("velocity", m_velocity.magnitude);
	}

	public override void SetVelocity(Vector2 velocity)
	{
		m_velocity.x = velocity.x * (m_moveSpeed + m_bonusMoveSpeed[m_level]);
		m_velocity.z = velocity.y * (m_moveSpeed + m_bonusMoveSpeed[m_level]);
	}

	private GameObject m_hand;
    private Animator m_Animator;
}
