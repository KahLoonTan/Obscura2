using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class FindPlaceType : MonoBehaviour {

	// Use this for initialization
	public float latitude=0;
	public float longitude=0;
	public float oldLat = 0;
	public float oldLon = 0;
	public string typePlace;
	public string namePlace;
	public string API;
	public Text locationData;
	public Image locationBg;
	public LevelController lc;
	public static bool callGetPlace = false;

	IEnumerator Start () {
		Debug.Log ("start()");
		while (!Input.location.isEnabledByUser) {
			print ("Activate gps");
			yield return new WaitForSeconds (1f);
		}

		Input.location.Start (10f, 5);

		int maxWait = 20;
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait>0){
			yield return new WaitForSeconds (1f);
			maxWait--;
		}

		if (maxWait < 1){
			print ("Timed Out");
			yield break;
		}

		if(Input.location.status == LocationServiceStatus.Failed){
			print ("Unable to determine device location");
			yield break;
		} else{
			//print ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " ");

		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;
		//locationData = gpsText.GetComponent<Text> ();
		yield return new WaitForSeconds(5f);
		StartCoroutine ("getType");
		while(Input.location.isEnabledByUser){
			yield return new WaitForSeconds(1f);
		}

		yield return StartCoroutine (Start());



	}

	public IEnumerator getType(){
		print ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " ");
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;



		string url= String.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=100&key={2}",latitude,longitude,API);
		WWW www = new WWW (url);
		yield return www;

		LevelController.webData = www.text.ToLower ();

		if (LevelController.webData.Contains ("university")) {
			locationData.text = "You are near a <color=green>University</color>\nYou can now unlock <color=blue>The Library</color>";
		} else if (LevelController.webData.Contains ("library")) {
			locationData.text = "You are near a <color=green>Library</color>\nYou can now unlock <color=blue>The Library</color>";
		} else if (LevelController.webData.Contains ("school")) {
			locationData.text = "You are near a <color=green>School</color>\nYou can now unlock <color=blue>The Library</color>";
		}else if (LevelController.webData.Contains ("campground")) {
			locationData.text = "You are near a <color=green>Campground</color>\nYou can now unlock <color=blue>Dark Forest</color>";
		} else if (LevelController.webData.Contains ("park")) {
			locationData.text = "You are near a <color=green>Park</color>\nYou can now unlock <color=blue>Dark Forest</color>";
		}else { //city and other
			locationData.text = "You are near a <color=green>City</color>\nYou can now unlock <color=blue>Forgotten Town</color>";
		}
		locationData.text += "\nLatitude -> " + latitude + "\n" + "Longitude -> " + longitude;
		locationData.supportRichText = false;

		//bool political = www.text.ToLower().Contains("political");
		//Debug.Log (political);

		oldLat = latitude;
		oldLon = longitude;
		while (oldLat == latitude && oldLon == longitude) {
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;

			yield return new WaitForSeconds (1f);
		}
		if(oldLat!=0&&oldLon!=0)
		lc.setDistance(distanceCalc (oldLat, latitude, oldLon, longitude));
		//yield return new WaitUntil(()=> (oldLat != lat || oldLon != lon));
		yield return new WaitForSeconds(30);
		yield return  StartCoroutine (getType());
	}




	public void textOnOff(){
		Color textColor = new Color (255, 255, 255, 255);
		Color bgColor = new Color (0, 0, 0, 0.6f);

		if (locationData.color.a == 0) {
			locationData.supportRichText = true;
			locationData.color = textColor;
			locationBg.color = bgColor;
			locationBg.raycastTarget = true;
			locationData.raycastTarget = true;

		} else {
			locationData.supportRichText = false;
			locationData.color = Color.clear;
			locationBg.color = Color.clear;
			locationBg.raycastTarget = false;
			locationData.raycastTarget = false;
		}
	}

	public float distanceCalc(float oldlat, float newlat, float oldlon, float newlon){
		float dlon = newlon - oldlon;
		float dlat = newlat - oldlat;
		float a = Mathf.Pow (Mathf.Pow (Mathf.Sin (dlat / 2f), 2f) + Mathf.Cos (oldlat) * Mathf.Cos (newlat) * (Mathf.Sin (dlon / 2f)), 2f);
		float c = 2 * Mathf.Atan2 (Mathf.Sqrt (a), Mathf.Sqrt (1 - a));
		Debug.Log (6371 * c);
		return 6371 * c;
	}
}
