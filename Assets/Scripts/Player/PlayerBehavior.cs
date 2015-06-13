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

	public void SetVelocity(ref Vector2 velocity)
	{
		m_velocity.x = velocity.x * m_moveSpeed;
		m_velocity.z = velocity.y * m_moveSpeed;
	}

	public void Jump(float force)
	{
		if(m_controller.isGrounded)
		{
			m_velocity.y = force * m_jumpForce;
		}
	}

	public void SetIsItemEnabled(bool isItemEnabled)
	{
		if(m_equippedItem)
		{
			m_equippedItem.SetIsEnabled(isItemEnabled);
		}
	}

	void ProcessMovement()
	{
		m_hand.transform.LookAt(m_aimTarget);

		if(m_velocity.sqrMagnitude > Mathf.Epsilon)
		{
			m_velocity.x *= (m_friction * Time.deltaTime);
			m_velocity.z *= (m_friction * Time.deltaTime);
		}
		else
		{
			m_velocity.x = 0.0f;
			m_velocity.z = 0.0f;
		}


		//Debug.Log(m_velocity.y);
		//Debug.Log("Is Grounded: " + m_controller.isGrounded);
		//Debug.Log(m_velocity);

		m_controller.Move(m_velocity);

		if(!m_controller.isGrounded)
		{
			m_velocity.y -= m_gravity * Time.deltaTime;
		}
		else
		{
			m_velocity.y = 0.0f;
		}
		
		Debug.Log(m_controller.isGrounded);
	}

	private CharacterController m_controller;

	public GameObject m_tempInventoryItemPrefab;
	public Vector3 m_aimTarget;
	public float m_moveSpeed = 30.0f;
	public float m_jumpForce = 1.0f;
	public float m_friction = 0.3f;
	public float m_gravity = 9.81f;
	
	private GameObject m_hand;
	private InventoryItem m_equippedItem;
	private Vector3 m_velocity;
}
