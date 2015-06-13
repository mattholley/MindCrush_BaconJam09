using UnityEngine;
using System.Collections;

public class SensorConduit : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		if(transform.parent)
		{
			m_brain = transform.parent.GetComponent<AIBrain>();
			Debug.Assert(m_brain != null);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void RecieveSensorResult(ref SensorResult result)
	{
		m_brain.ProcessSensorResult(ref result);
	}

	private AIBrain m_brain;
}
