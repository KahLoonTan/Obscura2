using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustSlider : MonoBehaviour {

	// Use this for initialization
	public Slider slider;
	public Text distanceRemaining;
	float currDistance;
	void Start () {
		currDistance = PlayerPrefs.GetFloat ("Distance");
		slider.value = currDistance*1000;
		distanceRemaining.text = "Distance Remaining:\n" + (0.05f - currDistance)*1000 + "meters";
	}
	
	// Update is called once per frame
	void Update () {
		currDistance = PlayerPrefs.GetFloat ("Distance");
		if (currDistance >= 0.05) {
			slider.value = 0.05f * 1000;
			distanceRemaining.text = "Level is now \nunlockable";
		} else {
			slider.value = currDistance*1000;
			distanceRemaining.text = "Distance Remaining:\n" + (0.05f - currDistance)*1000 + "meters";
		}

	}

}
