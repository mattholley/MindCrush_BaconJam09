using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_deathTimer -= Time.deltaTime;
		if(m_deathTimer <= 0.0f)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Monster")
		{
			AIBrain brain = other.gameObject.GetComponent<AIBrain>();
			brain.health -= 10.0f;
			brain.ProcessKnockBack(gameObject, other.gameObject);
			Destroy (gameObject);
		}
	}

	private float m_deathTimer = 5.0f;
}
