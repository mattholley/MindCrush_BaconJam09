using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_target)
		{
			transform.rotation = Quaternion.Euler(AXONOGRAPHIC_DIRECTION);
			Vector3 cameraTarget = m_target.transform.position - transform.forward * m_followDistance;
			transform.position = Vector3.SmoothDamp(transform.position, cameraTarget, ref m_velocity, m_smoothing);
		}
	}


	public GameObject m_target;
	public float m_followDistance = 10.0f;
	public float m_smoothing = 1.0f;

	private Vector3 m_velocity;

	private Vector3 AXONOGRAPHIC_DIRECTION = new Vector3(30.0f, 45.0f, 0.0f);

}
