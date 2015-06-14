using UnityEngine;
using System.Collections;

public class TestItem : GenericItem {

	public int m_experience;

	protected override void SetAttributes(){
		base.SetAttributes();
		m_attributes.Add("NAME","Test Item");
		m_attributes.Add("ID","item_0000");
	}

	protected override void OnTouched(GameObject entity){
		//Debug.Log("Test override ontouched");
		base.OnTouched(entity);
	}

	protected override void Collect(GameObject entity){
		base.Collect(entity);
		if (entity.name == "Player"){
			OnApply(entity);
			Destroy (this.gameObject);
		}
	}

	public override void OnApply(GameObject entity){
		base.OnApply(entity);
		entity.GetComponent<HumanBehavior>().GainExperience(m_experience);
	}

	protected override void OnDestroy(){
		//Debug.Log ("Tracing this before destroying.");
	}
}
