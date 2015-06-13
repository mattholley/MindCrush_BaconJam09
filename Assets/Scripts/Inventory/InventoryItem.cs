using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Use()
	{

	}

	public string GetName() { return m_name; }

	private string m_name = "";
}
