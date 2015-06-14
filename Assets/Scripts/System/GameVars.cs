using UnityEngine;
using System.Collections;

public class GameVars : MonoBehaviour {

	public static int GameLevel;

	public float treeRate;
	public float monsterRate;

	public Light lightSource;

	static float treeLevel;
	static float monsterLevel;

	// Use this for initialization
	void Start () {
	
		LevelGenerator.OnNewLevelPrimitve += AddToGameLevel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddToGameLevel() {

		GameLevel++;

		treeLevel = GameLevel * treeRate;
		monsterLevel = GameLevel * monsterRate;

	}

	void OnDestroy() {
		LevelGenerator.OnNewLevelPrimitve -= AddToGameLevel;
	}

	public static float GetMonsterLevel() {

		return monsterLevel;
	}

	public static float GetTreeLevel() {
		
		return treeLevel;
	}

}
