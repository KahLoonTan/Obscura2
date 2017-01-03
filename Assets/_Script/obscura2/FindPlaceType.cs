using UnityEngine;
using System;
using System.Collections;

public class FindPlaceType : MonoBehaviour {

	// Use this for initialization
	public float latitude=0;
	public float longitude=0;
	public string API;

	IEnumerator Start () {
		string url= String.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&location_type=ROOFTOP&key={2}",latitude,longitude,API);
		WWW www = new WWW (url);
		yield return www;
		Debug.Log (www.text);
		bool political = www.text.ToLower().Contains("political");
		Debug.Log (political);
	}
	
	// Update is called once per frame

}
