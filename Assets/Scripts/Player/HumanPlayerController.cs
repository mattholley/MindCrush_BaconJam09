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
		//Aim
		RaycastHit hitInfo;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hitInfo))
		{
			m_playerBehavior.m_aimTarget = hitInfo.point;
		}

		//Movement
		Vector3 direction = Vector3.zero;
		direction.x += Input.GetAxis("Horizontal");
		direction.z += Input.GetAxis("Vertical");
		direction.Normalize();

		m_playerBehavior.SetVelocity(ref direction);
	}

	private PlayerBehavior m_playerBehavior;
}
