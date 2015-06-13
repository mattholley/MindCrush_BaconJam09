﻿using UnityEngine;
using System.Collections.Generic;

public class GenericItem : MonoBehaviour {

	public Dictionary<string, object> m_attributes;

	void Awake() {
		m_attributes = new Dictionary<string, object>();
	}

	// Use this for initialization
	void Start () {
		SetAttributes();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other){
		Debug.Log ("Touched by:"+other.gameObject.name);
		OnTouched (other.gameObject);
	}

	protected virtual void OnDestroy() {} // This gets called when Destroy() is called.

	public virtual void OnUsed(GameObject entity) {}

	protected virtual void OnTouched(GameObject entity) {
		Collect ();
	}

	protected virtual void Collect() {}

	protected virtual void SetAttributes() {}

}