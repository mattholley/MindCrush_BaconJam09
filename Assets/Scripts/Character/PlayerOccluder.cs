using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerOccluder : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		HashSet<GameObject> occludedObjects = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag("PlayerOcclude"));
		occludedObjects.ExceptWith(m_visibleObjects);

		foreach(GameObject obj in occludedObjects)
		{
			//SetObjectOcclusion(obj, false);
		}

		foreach(GameObject obj in m_visibleObjects)
		{
			//SetObjectOcclusion(obj, false);
			Debug.DrawLine(transform.position, obj.transform.position, Color.red);
		}
	}

	void SetObjectOcclusion(GameObject obj, bool isOccluded)
	{
		Debug.Assert(obj != null);
		if(obj != null)
		{
			Debug.Log (obj.name + " is " + isOccluded);

			Renderer renderer = obj.GetComponent<Renderer>();
			//renderer.enabled = !isOccluded;
			Color oldColor = renderer.material.color;
			oldColor.a = isOccluded ? 0.1f : 1.0f;
			renderer.material.color = oldColor;

			if(isOccluded)
			{
				m_visibleObjects.Remove(obj);
			}
			else
			{
				m_visibleObjects.Add(obj);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "PlayerOcclude")
		{
			RaycastHit hitInfo;
			if(Physics.Raycast(transform.position, (other.transform.position - transform.position).normalized, out hitInfo))
			{
				if(hitInfo.collider == other)
				{
					if(!m_visibleObjects.Contains(other.gameObject))
					{
						SetObjectOcclusion(other.gameObject, false);
					}
				}
				else
				{
					SetObjectOcclusion(other.gameObject, true);
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "PlayerOcclude")
		{
			SetObjectOcclusion(other.gameObject, true);
		}
	}

	private HashSet<GameObject> m_visibleObjects = new HashSet<GameObject>();
}
