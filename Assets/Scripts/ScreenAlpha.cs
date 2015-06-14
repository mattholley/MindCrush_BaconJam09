using UnityEngine;
using System.Collections;

public class ScreenAlpha : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GoingUp = false;
        alpha = 0.0f;
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
	}
	
	// Update is called once per frame
	void Update () {
	    if(GoingUp && alpha < 1.0f)
        {
            alpha += Time.deltaTime;
            if(alpha>=1.0f)
            {
                alpha = 1.0f;
            }
            gameObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
        }
	}

    public bool GoingUp;
    public float alpha;
}
