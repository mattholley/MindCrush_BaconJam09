using UnityEngine;
using System.Collections;

public class GenericItem : MonoBehaviour {

	protected string m_itemID = "testCollectible";
	protected string m_name = "My Test Item";

	public GameObject temp_player;

	// Use this for initialization
	void Start () {
		OnTouch (temp_player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTouch(GameObject entity){
		Debug.Log("Entity '"+entity.name+"' has collected this item '"+m_name+"' with an id of '"+m_itemID+".");
		Debug.Log ("Insert code to do stuff here, such as add to inventory or something.");
		Debug.Log ("Now that this object has been touched (collected), remove it from the game)");
		Destroy (this.gameObject);
	}

}
