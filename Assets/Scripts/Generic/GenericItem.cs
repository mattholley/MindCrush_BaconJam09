using UnityEngine;
using System.Collections.Generic;

public class GenericItem : MonoBehaviour {

	public Dictionary<string, object> m_attributes;

	public Collider temp_player;

	void Awake() {
		m_attributes = new Dictionary<string, object>();
	}

	// Use this for initialization
	void Start () {
		SetAttributes();
		OnTriggerEnter(temp_player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider entity){
		OnTouched (entity.gameObject);
	}

	protected virtual void OnDestroy() {} // This gets called when Destroy() is called.

	public virtual void OnUsed(GameObject entity) {}

	protected virtual void OnTouched(GameObject entity) {
		Collect ();
	}

	protected virtual void Collect() {}

	protected virtual void SetAttributes() {}

}
