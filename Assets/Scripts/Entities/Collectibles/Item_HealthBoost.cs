using UnityEngine;
using System.Collections;

public class Item_HealthBoost : GenericItem {

	public int m_healthGain;
	public float m_rotateSpeed;

	protected override void Update(){
		base.Update();
		transform.Rotate(0, m_rotateSpeed * Time.deltaTime, 0, Space.World);
	}

	protected override void SetAttributes(){
		base.SetAttributes();
		m_attributes.Add("NAME","Health Boost");
		m_attributes.Add("ID","item_0001");
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
		entity.GetComponent<HumanBehavior>().GainHealth(m_healthGain);
	}
	
	protected override void OnDestroy(){
		//Debug.Log ("Tracing this before destroying.");
	}
}
