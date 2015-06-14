using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

	public float fadeRate = 0.005f;
	public float riseRate = 0.1f;
	public float heightOffset = 2.0f;
	public GameObject target;
	public string text = "No Text";

	Text textComponent;
	Color textColor;
	float height = 0.0f;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
		textComponent.text = text;
		textColor = textComponent.color;
		transform.position = Camera.main.WorldToScreenPoint( target.transform.position + Vector3.up * heightOffset);
		height = heightOffset;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		height += riseRate;
		transform.position = Camera.main.WorldToScreenPoint( target.transform.position + Vector3.up * height);
		textColor.a -= fadeRate;
		textComponent.color = textColor;
	}

	void Update() {
		if (textColor.a <= 0)
		{
			Destroy(this);
		}
	}
}
