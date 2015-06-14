using UnityEngine;
using System.Collections;

public class CharacterBehavior : MonoBehaviour 
{

	/* TODO List
	 * =================
	 * - Movement
	 * - Weapon
	 * - Stats
	 */

	// Use this for initialization
	protected virtual void Start () 
	{
		m_controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
		ProcessMovement();
	}

	public void SetAngularVelocity(float angularVelocity)
	{
		m_angularVelocity = angularVelocity;
	}

	public virtual void SetVelocity(Vector2 velocity)
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

		Vector3 distance = (m_aimTarget - transform.position);

		float crossVal = Mathf.Sign(Vector3.Cross(transform.forward, distance.normalized).y);
		float dotVal = Vector3.Dot(transform.forward, distance.normalized);

		m_angularVelocity = crossVal * m_rotateSpeed;
		
		if(!m_controller.isGrounded)
		{
            m_velocity.y -= m_gravity * Time.deltaTime;
            transform.Rotate(new Vector3(0.0f, m_angularVelocity * Time.deltaTime * 10, 0.0f));
            m_controller.Move(m_velocity);
		}
		else
        {
            m_velocity.y = -m_controller.stepOffset / Time.deltaTime;
            transform.Rotate(new Vector3(0.0f, m_angularVelocity * Time.deltaTime * 10, 0.0f));
            m_controller.Move(m_velocity);
            m_velocity.y = 0.0f;
        }

	}

	public void GainExperience(int amount){
		m_experience += amount;
		while (m_experience >= m_expToLevel[m_level]){
			m_level++;
		}
	}

	protected CharacterController m_controller;
	protected InventoryItem m_equippedItem;
	protected Vector3 m_velocity;
	protected float m_angularVelocity;

	public GameObject m_tempInventoryItemPrefab;
	public Vector3 m_aimTarget;
	public float m_moveSpeed = 30.0f;
	public float m_rotateSpeed = 30.0f;
	public float m_jumpForce = 1.0f;
	public float m_friction = 0.3f;
	public float m_gravity = 9.81f;

	// Character Statistics
	public float[] m_knockbackPower;
	public float[] m_bonusMoveSpeed;
	public float[] m_weaponPower;
	public int[] m_health;

	// Player Statistics
	public int m_level = 0;
	public int m_experience = 0;
	public int[] m_expToLevel;
}
