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
	public string API;
	public Text locationData;
	//Text locationData;

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
				
				if (www.text [i] == ',' && www.text[i-1] == ']')
					break;
				counter = i;
				
			}
			strEnd = counter;
			string filterStr = www.text.Substring (strStart, strEnd - strStart);
			Debug.Log (filterStr);
		}

		locationData.text = "Latitude -> "+ latitude + "\n" + "Longitude -> " + longitude + "\n" + "Type of place -> ";


		bool political = www.text.ToLower().Contains("political");
		Debug.Log (political);

		oldLat = latitude;
		oldLon = longitude;
		while (oldLat == latitude && oldLon == longitude) {
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
			yield return new WaitForSeconds (1f);
		}

		//yield return new WaitUntil(()=> (oldLat != lat || oldLon != lon));

		yield return  StartCoroutine (getType());
	}
	// Update is called once per frame

}
