using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public float initialLightIntensity;
	public float initialRotation;

	float lightLevel;
	float rotation;
	float prevLightLevel;
	float prevRotation;

	float lightLevelLerpTime = 0.0f;
	float lightRotationLerpTime = 0.0f;

	float lerpTime = 15.0f;

	Light thisLight;

	// Use this for initialization
	void Start () {
		thisLight = GetComponent<Light>();

		LevelGenerator.OnNewLevelPrimitve += UpdateLightLevel;
		LevelGenerator.OnNewLevelPrimitve += RotateLight;

		prevLightLevel = lightLevel = initialLightIntensity;
		prevRotation = rotation = initialRotation;
	}
	
	// Update is called once per frame
	void Update () {
		//increment timer once per frame
		lightLevelLerpTime += Time.deltaTime;
		if (lightLevelLerpTime > lerpTime) {
			lightLevelLerpTime = lerpTime;
		}

		lightRotationLerpTime += Time.deltaTime;
		if (lightRotationLerpTime > lerpTime) {
			lightRotationLerpTime = lerpTime;
		}
		
		//lerp!
		float perc = lightLevelLerpTime / lerpTime;
		thisLight.intensity = Mathf.Lerp(prevLightLevel, lightLevel, perc);

		perc = lightRotationLerpTime / lerpTime;
		transform.localEulerAngles = new Vector3(Mathf.Lerp(prevRotation, rotation, perc), transform.localEulerAngles.y, transform.localEulerAngles.z);
	}



	void UpdateLightLevel() {
		prevLightLevel = lightLevel;
		lightLevelLerpTime = 0.0f;
		lightLevel = initialLightIntensity - GameVars.GetLightLevel();
	}

	void RotateLight(){
		prevRotation = rotation;
		lightRotationLerpTime = 0.0f;
		rotation = initialRotation - (GameVars.GameLevel * 1.0f);
		if (rotation < 0) {
			rotation = 0;
		}
	}
}
