using UnityEngine;
using System.Collections;

public class TestItem : GenericItem {

	protected override void SetAttributes(){
		base.SetAttributes();
		m_attributes.Add("NAME","Test Item");
		m_attributes.Add("ID","item_0000");
	}

	protected override void OnTouched(GameObject entity){
		//Debug.Log("Test override ontouched");
		base.OnTouched(entity);
	}

	protected override void Collect(){
		//Debug.Log ("Test override collect.");
		//Debug.Log ("Insert code to do stuff here, such as add to inventory or something.");
		//Debug.Log ("You picked up a '"+m_attributes["NAME"]+"'!");
		Destroy (this.gameObject);
	}

	protected override void OnDestroy(){
		//Debug.Log ("Tracing this before destroying.");
	}
}
