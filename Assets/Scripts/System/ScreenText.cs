using UnityEngine;
using System.Collections.Generic;

public class ScreenText : MonoBehaviour {

	struct Message {
		public string text;
		public GameObject target;
		public Message(string text, GameObject target) {
			this.text = text;
			this.target = target;
		}
	}

	public GameObject FloatingTextPrefab;
	static List<Message> messages = new List<Message>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (messages.Count > 0)
		{
			foreach(Message message in messages)
			{
				GameObject newFloatText = Instantiate(FloatingTextPrefab);
				newFloatText.transform.SetParent(transform, false);
				FloatingText fText = newFloatText.GetComponent<FloatingText>();
				fText.text = message.text;
				fText.target = message.target;
			}
			messages.Clear();
		}
	}

	public static void FloatText(string text, GameObject target) {
		messages.Add( new Message(text, target));
	}
}
