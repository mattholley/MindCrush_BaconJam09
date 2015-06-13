using UnityEngine;
using System.Collections;

public class VisualSensor : Sensor
{

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
	}

	void OnTriggerEnter(Collider other)
	{
		SensorResult result;
		result.sensor = this;
		result.obj = other.gameObject;
		result.enter = true;
		DispatchSensorResult(ref result);
	}

	void OnTriggerExit(Collider other)
	{
		SensorResult result;
		result.sensor = this;
		result.obj = other.gameObject;
		result.enter = false;
		DispatchSensorResult(ref result);
	}
}
