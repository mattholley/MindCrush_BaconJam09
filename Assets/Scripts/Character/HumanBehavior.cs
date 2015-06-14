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
        //Debug.Log(m_hand);
        m_hand.transform.LookAt(m_aimTarget);
        m_Animator.SetFloat("velocity", m_velocity.magnitude);
        m_speedMagnitude = m_velocity.magnitude;
	}

	private GameObject m_hand;
    private Animator m_Animator;

    public float m_speedMagnitude;
}
