﻿using UnityEngine;
using System.Collections;

public class LevelPrimitive : MonoBehaviour {

	public GameObject treeFab;
	public GameObject[] monsterPrefab;
	public GameObject groundPrefab;

	public int testLevel = 150;

	private Bounds prefabBounds;

	// Use this for initialization
	void Start () {
		prefabBounds = groundPrefab.GetComponent<Renderer>().bounds;
		GenerateTrees(testLevel);
		GenerateMonsters(testLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Vector3 GetRandomPositionInBounds(Bounds range) {
		float maxX = range.extents.x;
		float maxZ = range.extents.z;
		
		Vector3 randomPoint = new Vector3(Random.Range(-maxX, maxX), range.center.y, Random.Range(-maxZ, maxZ));
		
		return randomPoint + transform.position;
	}

	void GenerateTrees(int level) {
		for(int i = 0; i <= level; i++) {
			Vector3 spawnPos = GetRandomPositionInBounds(prefabBounds);
			GameObject newPrefab = (GameObject)Instantiate(treeFab, spawnPos, Quaternion.identity);
			newPrefab.transform.parent = transform;
		}
	}

	void GenerateMonsters(int monstersInLevel) {
		for (int i = 0; i <= monstersInLevel; i++){
			Vector3 spawnPos = GetRandomPositionInBounds(prefabBounds);
			int selectedMonster = Random.Range(0, monsterPrefab.Length);
			GameObject newPrefab = (GameObject)Instantiate(monsterPrefab[selectedMonster], spawnPos, Quaternion.identity);
			newPrefab.transform.parent = transform;
		}
	}

}
