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

	void ProcessMovement()
	{
		if(m_velocity.sqrMagnitude > Mathf.Epsilon)
		{
			m_velocity *= m_friction;
		}
		else
		{
			m_velocity = Vector3.zero;
		}

		transform.position += m_velocity;
	}

	public float m_moveSpeed;
	public float m_friction;
	public float m_gravity; // Maybe not needed

	private Vector3 m_velocity;
}
