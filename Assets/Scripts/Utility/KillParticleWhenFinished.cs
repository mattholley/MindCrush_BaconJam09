using UnityEngine;
using System.Collections;

public class KillParticleWhenFinished : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		m_particleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!m_particleSystem || !m_particleSystem.IsAlive())
		{
			Destroy(gameObject);
		}
	}

	private ParticleSystem m_particleSystem;
}
