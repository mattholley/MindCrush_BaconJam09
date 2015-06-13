using UnityEngine;
using System.Collections;

public class GameVars : MonoBehaviour {

	public static int GameLevel;

	public int treeRate;
	public int monsterRate;

	static int treeLevel;
	static int monsterLevel;

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

	public static int GetMonsterLevel() {

		return monsterLevel;
	}

	public static int GetTreeLevel() {
		
		return treeLevel;
	}

}
