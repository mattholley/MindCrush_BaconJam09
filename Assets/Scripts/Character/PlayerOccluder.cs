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
		foreach(GameObject obj in occludedObjects)
		{
			SetObjectOcclusion(obj, false);
		}

		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		Debug.Assert(playerObject);
		if(playerObject)
		{
			Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(playerObject.transform.position);
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(playerScreenPosition);
			if(Physics.Raycast(ray, out hitInfo))
			{
				if(hitInfo.collider.tag == "PlayerOcclude")
				{
					SetObjectOcclusion(hitInfo.collider.gameObject, true);
				}
			}
		}
	}

	void SetObjectOcclusion(GameObject obj, bool isOccluded)
	{
		Debug.Assert(obj != null);
		if(obj != null)
		{
			obj.GetComponent<Occludee>().SetOccluded(isOccluded);
		}
	}
}
