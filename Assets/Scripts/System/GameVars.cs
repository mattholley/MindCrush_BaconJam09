using UnityEngine;
using System.Collections;

public class GameVars : MonoBehaviour {

	public static int GameLevel = 1;

	public float treeRate;
	public float monsterRate;
	public float lightRate;

	static float treeLevel;
	static float monsterLevel;
	static float lightLevel;

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
		lightLevel = GameLevel * lightRate;

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

	public static float GetLightLevel() {
		return lightLevel;
	}

}
