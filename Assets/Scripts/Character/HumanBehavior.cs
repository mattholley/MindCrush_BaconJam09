using UnityEngine;
using System.Collections;

public class HumanBehavior : CharacterBehavior {

	// Use this for initialization
	protected override void Start () {
		base.Start();
        m_Animator = GetComponent<Animator>();

		GameObject inventoryItemObject = GameObject.Instantiate(m_tempInventoryItemPrefab);
		if(inventoryItemObject)
		{
			inventoryItemObject.transform.SetParent(m_hand.transform, false);
			
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
        m_hand.transform.LookAt(m_aimTarget);

		Vector2 animVelocity = new Vector2(m_velocity.x, m_velocity.z);
		m_Animator.SetFloat("velocity", animVelocity.magnitude);
	}

	public override void SetVelocity(Vector2 velocity)
	{
		m_velocity.x = velocity.x * (m_moveSpeed + m_bonusMoveSpeed[m_level]);
		m_velocity.z = velocity.y * (m_moveSpeed + m_bonusMoveSpeed[m_level]);
	}

	public override void GainHealth (int amount)
	{
		m_currentHealth += amount;
		if (m_currentHealth > m_maxHealth[m_level]){
			m_currentHealth = m_maxHealth[m_level];
		}
	}

    private Animator m_Animator;
	public GameObject m_hand;
}
