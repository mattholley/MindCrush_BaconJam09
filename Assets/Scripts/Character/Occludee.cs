using UnityEngine;
using System.Collections;

public class Occludee : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Renderer renderer = GetComponent<Renderer>();
		Color oldColor = renderer.material.color;
		oldColor.a = Mathf.SmoothDamp(oldColor.a, m_occludeTarget ? 0.01f : 1.0f, ref m_smoothVelocity, 0.1f);
		renderer.material.color = oldColor;

	}

	public void SetOccluded(bool isOccluded)
	{
		if(m_occludeTarget != isOccluded)
		{
			m_occludeTarget = isOccluded;
		}
	}

	private bool m_occludeTarget;
	private float m_smoothVelocity;
}
