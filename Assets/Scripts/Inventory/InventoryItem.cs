using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetIsEnabled(bool isEnabled)
	{
		if(m_isEnabled != isEnabled)
		{
			if(isEnabled)
			{
				Enable();
			}
			else
			{
				Disable();
			}
		}
	}

	protected virtual void Enable()
	{
		m_isEnabled = true;
	}

	protected virtual void Disable()
	{
		m_isEnabled = false;
	}

	public string GetName() { return m_name; }

	private string m_name = "";
	private bool m_isEnabled = false;

	public bool itemEnabled { get { return m_isEnabled; } set {}}

}
