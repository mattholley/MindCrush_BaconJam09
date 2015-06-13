using UnityEngine;
using System.Collections;

public class FlashLight : WeaponItem 
{

	// Use this for initialization
	void Start () 
	{
		m_light = GetComponentInChildren<Light>();
		m_lightCollider = GetComponentInChildren<Collider>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(itemEnabled)
		{
			m_strobeTimer += Time.deltaTime;
			if(m_strobeTimer >= m_strobeTimerMax)
			{
				m_light.enabled = !m_light.enabled;

				if(m_light.enabled)
				{
					m_light.color = (m_light.color == Color.magenta ) ? Color.white : Color.magenta;
				}

				m_strobeTimer = 0.0f;
			}
		}
	}

	protected override void Enable() 
	{
		base.Enable();
		m_light.color = Color.magenta;
		m_lightCollider.enabled = true;
	}

	protected override void Disable()
	{
		base.Disable();
		m_light.enabled = true;
        m_light.color = Color.white;
		m_lightCollider.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Monster")
		{
			AIBrain brain = other.gameObject.GetComponent<AIBrain>();
			brain.health -= 20000.0f;
		}
	}

	private Light m_light;
	private Collider m_lightCollider;
	private float m_strobeTimer = 0.0f;

    public float m_strobeTimerMax = 0.02f;
    public GameObject m_emittedLight;
}
