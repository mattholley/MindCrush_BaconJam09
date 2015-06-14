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
		//occludedObjects.ExceptWith(m_visibleObjects);
		//occludedObjects.ExceptWith(m_potentiallyVisible);

		foreach(GameObject obj in occludedObjects)
		{
			//SetObjectOcclusion(obj, true);
		}

		//[Matt] Can't remove while in the foreach, and no way around it seems
		HashSet<GameObject> nextPotentialSet = new HashSet<GameObject>(m_potentiallyVisible);

		//Attempt to make the potential set visible with raycasts
		foreach(GameObject obj in nextPotentialSet)
		{
			if(obj == null)
			{
				m_potentiallyVisible.Remove(obj);
			}
			else
			{
				RaycastHit hitInfo;
				Vector3 otherAtEyeLevel = obj.transform.position;
				otherAtEyeLevel.y = transform.position.y;

				Debug.DrawLine(transform.position, otherAtEyeLevel, Color.blue);
				if(Physics.Raycast(transform.position, (otherAtEyeLevel - transform.position).normalized, out hitInfo))
				{
					if(hitInfo.collider.gameObject == obj)
					{
						SetObjectOcclusion(obj, false);
						m_potentiallyVisible.Remove(obj);
					}
				}
			}
		}

		HashSet<GameObject> nextVisibleSet = new HashSet<GameObject>(m_visibleObjects);

		//Attempt to make the visible objects occluded with raycasts	
		foreach(GameObject obj in nextVisibleSet)
		{
			if(obj == null)
			{
				m_visibleObjects.Remove(obj);
			}
			else
			{
				RaycastHit hitInfo;
				Vector3 otherAtEyeLevel = obj.transform.position;
				otherAtEyeLevel.y = transform.position.y;
				if(Physics.Raycast(transform.position, (otherAtEyeLevel - transform.position).normalized, out hitInfo))
				{
					if(hitInfo.collider.gameObject != obj)
					{
						SetObjectOcclusion(obj, true);
						m_potentiallyVisible.Add(obj);
					}
				}

				Debug.DrawLine(transform.position, otherAtEyeLevel, Color.red);
			}
		}
	}

	void SetObjectOcclusion(GameObject obj, bool isOccluded)
	{
		Debug.Assert(obj != null);
		if(obj != null)
		{
			//Debug.Log (obj.name + " is " + isOccluded);
			obj.GetComponent<Occludee>().SetOccluded(isOccluded);

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
		//Debug.Log(other.gameObject.name);
		if(other.tag == "PlayerOcclude")
		{
			m_potentiallyVisible.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "PlayerOcclude")
		{
			m_potentiallyVisible.Remove(other.gameObject);
			SetObjectOcclusion(other.gameObject, true);
		}
	}

	private HashSet<GameObject> m_potentiallyVisible = new HashSet<GameObject>();
	private HashSet<GameObject> m_visibleObjects = new HashSet<GameObject>();
}
