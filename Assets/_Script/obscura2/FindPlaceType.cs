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
			print ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " ");

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
		string url= String.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key={2}",latitude,longitude,API);
		WWW www = new WWW (url);
		yield return www;
		if (latitude != 0 && longitude != 0) {
			int strStart = www.text.IndexOf ("\"address_components\"") + "\"address_components\"".Length;
			int strEnd;
			int counter = strStart;
			for(int i = counter; i<www.text.Length;i++) {
				
				if (www.text [i] == ',' && www.text[i-1] == '}')
					break;
				counter = i;
				
			}
			strEnd = counter;
			string filterStr = www.text.Substring (strStart, strEnd - strStart);
			typePlace = getType (filterStr);
			namePlace = getName (filterStr);

			Debug.Log (typePlace);
		}

		locationData.text = "Latitude -> " + latitude + " " + namePlace + "\n" + "Longitude -> " + longitude + "\n" + "Type of place ->" + typePlace;


		bool political = www.text.ToLower().Contains("political");
		Debug.Log (political);

		oldLat = latitude;
		oldLon = longitude;
		while (oldLat == latitude && oldLon == longitude) {
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
			yield return new WaitForSeconds (1f);
		}
		lc.setDistance(distanceCalc (oldLat, latitude, oldLon, longitude));
		//yield return new WaitUntil(()=> (oldLat != lat || oldLon != lon));

		yield return  StartCoroutine (getType());
	}


	public string getType(string abc){
		int typeStart = abc.IndexOf ("\"types\" : [") + "\"types\" : [".Length;
		int typeEnd = abc.IndexOf ("]");
		string type = abc.Substring (typeStart, typeEnd - typeStart);
		type = type.Replace('"',' ');

		return type;
	}

	public string getName(string abc){
		int nameStart = abc.IndexOf ("\"short_name\" : \"") + "\"short_name\" : \"".Length;
		int typeStart = abc.IndexOf ("\"types\"") - 18; 

		return abc.Substring (nameStart, typeStart - nameStart );
	}

	public void textOnOff(){
		Color textColor = new Color (255, 255, 255, 255);
		Color bgColor = new Color (0, 0, 0, 0.4f);

		if (locationData.color.a == 0) {
			locationData.color = textColor;
			locationBg.color = bgColor;

		} else {
			locationData.color = Color.clear;
			locationBg.color = Color.clear;
		}
	}

	public float distanceCalc(float oldlat, float newlat, float oldlon, float newlon){
		float dlon = newlon - oldlon;
		float dlat = newlat - oldlat;
		float a = Mathf.Pow (Mathf.Pow (Mathf.Sin (dlat / 2f), 2f) + Mathf.Cos (oldlat) * Mathf.Cos (newlat) * (Mathf.Sin (dlon / 2f)), 2f);
		float c = 2 * Mathf.Atan2 (Mathf.Sqrt (a), Mathf.Sqrt (1 - a));
		return 6371 * c/1000;
	}
}
