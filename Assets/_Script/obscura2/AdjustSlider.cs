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
		slider.value = currDistance;
		distanceRemaining.text = "Distance Remaining:\n" + (1000 - currDistance);
	}
	
	// Update is called once per frame
	void Update () {
		currDistance = PlayerPrefs.GetFloat ("Distance");
		slider.value = currDistance;
		distanceRemaining.text = "Distance Remaining:\n" + (1000 - currDistance);
	}
}
