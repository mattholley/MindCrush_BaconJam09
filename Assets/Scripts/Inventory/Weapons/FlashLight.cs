using UnityEngine;
using System.Collections;

public class FlashLight : WeaponItem 
{

	// Use this for initialization
	void Start () 
	{
		m_light = GetComponentInChildren<Light>();
		m_lightCollider = GetComponentInChildren<Collider>();
		m_lightCollider.enabled = false;
		m_light.color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(itemEnabled)
		{

		}
	}

	protected override void Enable() 
	{
		base.Enable();
		m_light.color = Color.white;
		m_lightCollider.enabled = true;
		print ("PEW!!");
	}

	protected override void Disable()
	{
		base.Disable();
		m_light.enabled = true;
        m_light.color = Color.gray;
		m_lightCollider.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Monster")
		{
			AIBrain brain = other.gameObject.GetComponent<AIBrain>();
			brain.health -= 1.0f;
            brain.ProcessKnockBack(gameObject, other.gameObject);
		}
	}

	private Light m_light;
	private Collider m_lightCollider;
	private float m_strobeTimer = 0.0f;

    public float m_strobeTimerMax = 0.02f;
    public GameObject m_emittedLight;
}
