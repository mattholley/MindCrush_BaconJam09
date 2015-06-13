using UnityEngine;
using System.Collections;

public class AwarenessSensor : Sensor 
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

	void OnTriggerExit(Collider other)
	{
		SensorResult result;
		result.sensor = this;
		result.obj = other.gameObject;
		result.enter = false;
		DispatchSensorResult(ref result);
	}
}
