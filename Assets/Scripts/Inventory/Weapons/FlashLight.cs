using UnityEngine;
using System.Collections;

public class FlashLight : WeaponItem 
{

	// Use this for initialization
	void Start () 
	{
		m_light = GetComponentInChildren<Light>();
		m_lightCollider = GetComponentInChildren<Collider>();
		m_light.color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	protected override void Enable() 
	{
		base.Enable();
		m_light.color = Color.white;

		GameObject projectile = GameObject.Instantiate(m_projectile);
		if(projectile)
		{
			projectile.transform.position = transform.position + (transform.forward * 1.0f);
			projectile.transform.rotation = transform.rotation;

			Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
			if(rigidbody)
			{
				Vector3 aimVec = transform.parent.forward;
				aimVec.y = 0.0f;
				rigidbody.AddForce(aimVec.normalized * m_shootForce);
			}
		}
	}

	protected override void Disable()
	{
		base.Disable();
		m_light.enabled = true;
        m_light.color = Color.gray;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Monster")
		{
			CharacterBehavior character = other.gameObject.GetComponent<CharacterBehavior>();
			character.m_moveSpeedModifier = 0.25f;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Monster")
		{
			CharacterBehavior character = other.gameObject.GetComponent<CharacterBehavior>();
			character.m_moveSpeedModifier = 1.0f;
		}
	}

	private Light m_light;
	private Collider m_lightCollider;
	public float m_shootForce = 200.0f;
    public GameObject m_emittedLight;
	public GameObject m_projectile;
}
