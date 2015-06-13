using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public GameObject levelPrefab;
	public GameObject generationController;

	private float prefabWidth;
	private LinkedList<GameObject> levelPrimitives;

	// Use this for initialization
	void Start () {
		levelPrimitives = new LinkedList<GameObject>();

		prefabWidth = 100.0f;//levelPrefab.GetComponent<Transform>().bounds.extents.z;


		//Create initial level primitives
		GameObject newPrefab = Instantiate(levelPrefab);
		newPrefab.transform.parent = transform;
		levelPrimitives.AddFirst(newPrefab);

		SpawnPreviousLevelPrimitive();
		SpawnNextLevelPrimitive();

	}
	
	// Update is called once per frame
	void Update () {

		if (ReCenter(prefabWidth))
		{
			SpawnNextLevelPrimitive();
			DestroyLastLevelPrimitive();
		}
	}

	bool ReCenter(float threshold)
	{
		if (generationController.transform.position.z > (threshold)) {
			
			foreach (Transform child in transform)
			{
				child.Translate(0.0f, 0.0f, -threshold);
			}

			return true;
		}

		return false;
	}

	void SpawnNextLevelPrimitive()
	{
		GameObject topPrimitive = levelPrimitives.First.Value;

		Vector3 spawnPos = topPrimitive.transform.position + new Vector3(0.0f, 0.0f, prefabWidth);

		GameObject newPrefab = (GameObject)Instantiate(levelPrefab, spawnPos, Quaternion.identity);
		newPrefab.transform.parent = transform;
		levelPrimitives.AddFirst(newPrefab);

	}

	void SpawnPreviousLevelPrimitive()
	{
		GameObject bottomPrimitive = levelPrimitives.Last.Value;
		
		Vector3 spawnPos = bottomPrimitive.transform.position - new Vector3(0.0f, 0.0f, prefabWidth);
		
		GameObject newPrefab = (GameObject)Instantiate(levelPrefab, spawnPos, Quaternion.identity);
		newPrefab.transform.parent = transform;
		levelPrimitives.AddLast(newPrefab);
		
	}

	void DestroyLastLevelPrimitive()
	{
		GameObject deadPrefab = levelPrimitives.Last.Value;
		levelPrimitives.RemoveLast();
		
		Destroy(deadPrefab);
	}
}
