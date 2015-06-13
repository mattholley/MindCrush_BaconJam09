using UnityEngine;
using System.Collections;

public class HumanPlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		m_playerBehavior = GetComponent<PlayerBehavior>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 direction = Vector3.zero;
		direction.x += Input.GetAxis("Horizontal");
		direction.z += Input.GetAxis("Vertical");

		m_playerBehavior.SetVelocity(ref direction);
	}

	private PlayerBehavior m_playerBehavior;
}
