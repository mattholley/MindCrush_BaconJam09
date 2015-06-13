using UnityEngine;
using System.Collections;

public struct SensorResult
{
	public Sensor sensor;
	public GameObject obj;
	public bool enter;
}

public class Sensor : MonoBehaviour 
{

	// Use this for initialization
	protected virtual void Start () 
	{
		if(transform.parent)
		{
			m_sensorConduit = transform.parent.GetComponent<SensorConduit>();
			Debug.Assert(m_sensorConduit);
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
	
	}

	protected void DispatchSensorResult(ref SensorResult result)
	{
		m_sensorConduit.RecieveSensorResult(ref result);
	}

	private SensorConduit m_sensorConduit;
}
