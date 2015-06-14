using UnityEngine;
using System.Collections;

public class GameVars : MonoBehaviour {

	public static int GameLevel = 1;

	public float treeRate;
	public float monsterRate;
	public float lightRate;

	public delegate void GameLevelUpAction();
	public static event GameLevelUpAction OnGameLevelUp;

	static float treeLevel;
	static float monsterLevel;
	static float lightLevel;

	// Use this for initialization
	void Start () {
	
		LevelGenerator.OnNewLevelPrimitve += AddToGameLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void AddToGameLevel() {

		GameLevel++;

		treeLevel = GameLevel * treeRate;
		monsterLevel = GameLevel * monsterRate;
		lightLevel = GameLevel * lightRate;

		OnGameLevelUp();

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
