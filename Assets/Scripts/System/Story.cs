using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Story : MonoBehaviour {


	struct TimedMessage {
		public string text;
		public float time;
		public TimedMessage(string text, float time) {
			this.text = text;
			this.time = time;
		}
	}

	Dictionary<int, TimedMessage> messages = new Dictionary<int, TimedMessage>();
	Queue<TimedMessage> queue = new Queue<TimedMessage>();
	
	GameObject target;

	// Use this for initialization
	void Start () {

		queue.Enqueue(new TimedMessage("", 5.0f));
		queue.Enqueue(new TimedMessage("Mom?", 1.0f));
		queue.Enqueue(new TimedMessage("Dad?", 3.0f));
		queue.Enqueue(new TimedMessage("Where are you?", 3.0f));

		messages[5] = new TimedMessage("I'm coming to find you!", 1.0f);

		GameVars.OnGameLevelUp += QueueMessageForLevel;

		target = GameObject.FindGameObjectWithTag("Player");

		StartCoroutine(DisplayMessages());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DisplayMessages() {
		TimedMessage message = queue.Dequeue();
		ScreenText.FloatText(message.text, target);
		yield return new WaitForSeconds(message.time);
		if (queue.Count > 0) {
			StartCoroutine(DisplayMessages());
		}
	}

	void QueueMessageForLevel() {
		if (messages.ContainsKey(GameVars.GameLevel))
		{
			if (queue.Count <= 0) {
				queue.Enqueue(messages[GameVars.GameLevel]);
				StartCoroutine(DisplayMessages());
			} else {
				queue.Enqueue(messages[GameVars.GameLevel]);
			}
		}
	}
}
