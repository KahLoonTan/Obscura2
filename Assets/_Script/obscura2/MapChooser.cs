using UnityEngine;
using System.Collections;

public class MapChooser : MonoBehaviour {

	// Use this for initialization
	public GameObject city;
	public GameObject park;
	public GameObject airport;
	public GameObject village;
	void Start () {
		string areaButton = "Area" + PlayerPrefs.GetString ("Area");
		string map = PlayerPrefs.GetString (areaButton).ToLower();

		if (map == "city") {
			city.SetActive (true);
		} else if (map == "park") {
			park.SetActive (true);
		} else if (map == "airport") {
			airport.SetActive (true);
		} else if (map == "village") {
			village.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
