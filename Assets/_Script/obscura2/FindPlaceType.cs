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

		//if (latitude != 0 && longitude != 0) {

			string url= String.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=100&key={2}",latitude,longitude,API);
			WWW www = new WWW (url);
			yield return www;

			LevelController.webData = www.text.ToLower ();
			/*if(wwwData.Contains("park")){
				PlayerPrefs.SetInt("Park",1);
			}
			if(wwwData.Contains("airport")){
				PlayerPrefs.SetInt("Airport",1);
			}
			if(wwwData.Contains("point_of_interest")||(wwwData.Contains("shopping_mall"))||(wwwData.Contains("store"))||(wwwData.Contains("convenience_store"))){
				PlayerPrefs.SetInt ("City", 1);
			}
			if (wwwData.Contains ("sublocality_level") || wwwData.Contains ("sublocality") || wwwData.Contains ("establishment") || wwwData.Contains ("lodging") || wwwData.Contains ("locality")) {
				PlayerPrefs.SetInt ("Village", 1);
			}
			Debug.Log (wwwData.Contains ("sublocality_level") || wwwData.Contains ("sublocality") || wwwData.Contains ("establishment") || wwwData.Contains ("lodging") || wwwData.Contains ("locality"));	
			callGetPlace=false;
			*/
		//}

		locationData.text = "Latitude -> " + latitude + "\n" + "Longitude -> " + longitude;


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
			locationData.color = textColor;
			locationBg.color = bgColor;
			locationBg.raycastTarget = true;
			locationData.raycastTarget = true;

		} else {
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
