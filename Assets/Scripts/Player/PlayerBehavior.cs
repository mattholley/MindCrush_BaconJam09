using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour 
{

	/* TODO List
	 * =================
	 * - Movement
	 * - Weapon
	 * - Stats
	 */

	// Use this for initialization
	void Start () 
	{
		m_controller = GetComponent<CharacterController>();

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
	void Update () 
	{
		ProcessMovement();
	}

	public void SetVelocity(ref Vector3 velocity)
	{
		m_velocity = velocity * m_moveSpeed;
	}

	public void UseItem()
	{
		m_equippedItem.Use();
	}

	void ProcessMovement()
	{
		m_hand.transform.LookAt(m_aimTarget);

		if(m_velocity.sqrMagnitude > Mathf.Epsilon)
		{
			m_velocity *= m_friction;
		}
		else
		{
			m_velocity = Vector3.zero;
		}

		m_controller.Move(m_velocity * Time.deltaTime);
	}

	private CharacterController m_controller;

	public GameObject m_tempInventoryItemPrefab;
	public Vector3 m_aimTarget;
	public float m_moveSpeed;
	public float m_friction;
	public float m_gravity; // Maybe not needed
	
	private GameObject m_hand;
	private InventoryItem m_equippedItem;
	private Vector3 m_velocity;
}
