using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddItem(InventoryItem item)
	{
		if(item)
		{
			m_items.Add(item.GetName(), item);
		}
	}

	public InventoryItem RemoveItem(string name)
	{
		InventoryItem item = m_items[name];
		m_items.Remove(name);
		return item;
	}

	private Dictionary<string, InventoryItem> m_items = new Dictionary<string, InventoryItem>();
}
