using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	public float distance=0f;
	public float distLimit;
	public Navigation navigation;
	public static string webData="empty";
	public GameObject confirmationPanel;
	public GameObject backButton;
	public GameObject proceedButton;
	public GameObject cancelButton;
	public Text confirmObjText;
	string confirmationText;
	void Start () {

		PlayerPrefs.SetString ("Area", "0");
		//PlayerPrefs.SetString ("Area4", "");
		PlayerPrefs.SetString ("Area2", "DarkForest");
		PlayerPrefs.SetString ("Area3", "Library");
		PlayerPrefs.SetString ("AreaConfirm1", "True");
		PlayerPrefs.SetString ("AreaConfirm2", "True");
		PlayerPrefs.SetString ("AreaConfirm3", "True");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void area1(){
		string type = PlayerPrefs.GetString ("Area1");
		PlayerPrefs.SetString ("Area", "1");
		if (type != "Library" && type != "DarkForest" && type != "ForgottenTown") {

			if (webData.Contains ("university")) {
				PlayerPrefs.SetString ("Area1", "Library");
				PlayerPrefs.SetString ("Place", "University");
			} else if (webData.Contains ("library")) {
				PlayerPrefs.SetString ("Area1", "Library");
				PlayerPrefs.SetString ("Place", "Library");
			} else if (webData.Contains ("school")) {
				PlayerPrefs.SetString ("Area1", "Library");
				PlayerPrefs.SetString ("Place", "School");
			}else if (webData.Contains ("campground")) {
				PlayerPrefs.SetString ("Area1", "DarkForest");
				PlayerPrefs.SetString ("Place", "Camp Ground");
			} else if (webData.Contains ("park")) {
				PlayerPrefs.SetString ("Area1", "DarkForest");
				PlayerPrefs.SetString ("Place", "Park");
			}else { //city and other
				PlayerPrefs.SetString ("Area1", "ForgottenTown");
				PlayerPrefs.SetString ("Place", "City");
			}
			confirmation (false);
		}else{
			confirmation (true);
		}



	}
	public void area2(){
		string type = PlayerPrefs.GetString ("Area2");
		PlayerPrefs.SetString ("Area", "2");
		if (type != "Library" && type != "DarkForest" && type != "ForgottenTown") {

			if (webData.Contains ("university")) {
				PlayerPrefs.SetString ("Area2", "Library");
				PlayerPrefs.SetString ("Place", "University");
			} else if (webData.Contains ("library")) {
				PlayerPrefs.SetString ("Area2", "Library");
				PlayerPrefs.SetString ("Place", "Library");
			} else if (webData.Contains ("school")) {
				PlayerPrefs.SetString ("Area2", "Library");
				PlayerPrefs.SetString ("Place", "School");
			}else if (webData.Contains ("campground")) {
				PlayerPrefs.SetString ("Area2", "DarkForest");
				PlayerPrefs.SetString ("Place", "Camp Ground");
			} else if (webData.Contains ("park")) {
				PlayerPrefs.SetString ("Area2", "DarkForest");
				PlayerPrefs.SetString ("Place", "Park");
			}else { //city and other
				PlayerPrefs.SetString ("Area2", "ForgottenTown");
				PlayerPrefs.SetString ("Place", "City");
			}
			confirmation (false);
		}else{
			confirmation (true);
		}

	}
	public void area3(){
		string type = PlayerPrefs.GetString ("Area3");
		PlayerPrefs.SetString ("Area", "3");
		if (type != "Library" && type != "DarkForest" && type != "ForgottenTown") {

			if (webData.Contains ("university")) {
				PlayerPrefs.SetString ("Area3", "Library");
				PlayerPrefs.SetString ("Place", "University");
			} else if (webData.Contains ("library")) {
				PlayerPrefs.SetString ("Area3", "Library");
				PlayerPrefs.SetString ("Place", "Library");
			} else if (webData.Contains ("school")) {
				PlayerPrefs.SetString ("Area3", "Library");
				PlayerPrefs.SetString ("Place", "School");
			}else if (webData.Contains ("campground")) {
				PlayerPrefs.SetString ("Area3", "DarkForest");
				PlayerPrefs.SetString ("Place", "Camp Ground");
			} else if (webData.Contains ("park")) {
				PlayerPrefs.SetString ("Area3", "DarkForest");
				PlayerPrefs.SetString ("Place", "Park");
			}else { //city and other
				PlayerPrefs.SetString ("Area3", "ForgottenTown");
				PlayerPrefs.SetString ("Place", "City");
			}
			confirmation (false);
		}else{
			confirmation (true);
		}


	}
	public void area4(){
		if (webData.Contains ("empty")) {
			confirmationPanel.SetActive (true);
			confirmObjText.text = "Still initializing\nCheck \"Location\" for status";
			backButton.SetActive (true);
		} else {
			string type = PlayerPrefs.GetString ("Area4");
			PlayerPrefs.SetString ("Area", "4");
			if (type != "Library" && type != "DarkForest" && type != "ForgottenTown") {

				if (webData.Contains ("university")) {
					PlayerPrefs.SetString ("Area4", "Library");
					PlayerPrefs.SetString ("Place", "University");
				} else if (webData.Contains ("library")) {
					PlayerPrefs.SetString ("Area4", "Library");
					PlayerPrefs.SetString ("Place", "Library");
				} else if (webData.Contains ("school")) {
					PlayerPrefs.SetString ("Area4", "Library");
					PlayerPrefs.SetString ("Place", "School");
				}else if (webData.Contains ("campground")) {
					PlayerPrefs.SetString ("Area4", "DarkForest");
					PlayerPrefs.SetString ("Place", "Camp Ground");
				} else if (webData.Contains ("park")) {
					PlayerPrefs.SetString ("Area4", "DarkForest");
					PlayerPrefs.SetString ("Place", "Park");
				}else { //city and other
					PlayerPrefs.SetString ("Area4", "ForgottenTown");
					PlayerPrefs.SetString ("Place", "City");
				}
				confirmation (false);


			}else{
				confirmation (true);
			}
		}

	}

	public void chooseMap(){
		string areaNum = PlayerPrefs.GetString ("Area");
		string type = PlayerPrefs.GetString ("Area" + areaNum);
		PlayerPrefs.SetString ("AreaConfirm" + areaNum, "True");
		confirmObjText.text = "Loading <color=lime>" + type + "</color>\nPlease wait...";
		proceedButton.SetActive (false);
		cancelButton.SetActive (false);
		backButton.SetActive (false);
		//Application.LoadLevel (type);
		SceneManager.LoadScene(type);
	}

	public void cancelMap(){
		if (backButton.activeSelf == true) {
			backButton.SetActive(false);
		} else {
			string areaNum = PlayerPrefs.GetString ("Area");
			if (PlayerPrefs.GetString ("AreaConfirm" + areaNum) != "True") {
				PlayerPrefs.SetString ("Area" + areaNum, "Null");
			}
		}


		confirmationPanel.SetActive (false);
	}

	void confirmation(bool unlocked){
		string areaNum = PlayerPrefs.GetString ("Area");
		string type = PlayerPrefs.GetString ("Area" + areaNum);

		switch (unlocked) {
		case true:
			
			confirmationText = "You will enter <color=lime>" + type + "</color>\nProceed?";
			confirmationPanel.SetActive (true);
			proceedButton.SetActive(true);
			cancelButton.SetActive(true);
			confirmObjText.text = confirmationText;
			break;
		case false:
			string place = PlayerPrefs.GetString ("Place");
			confirmationText = "You are near <color=cyan>" + place + "</color>\nYou will enter <color=lime>" + type + "</color>\nProceed?";
			confirmationPanel.SetActive (true);
			proceedButton.SetActive(true);
			cancelButton.SetActive(true);
			confirmObjText.text = confirmationText;
			break;
		}
		
	}

	public void setDistance(float d){
		float currDistance = PlayerPrefs.GetFloat ("Distance");
		if ((currDistance + d) > distLimit) {
			PlayerPrefs.SetFloat ("Distance", distLimit);
		} else {
			PlayerPrefs.SetFloat ("Distance", currDistance+d);
		}

	}

	public void resetDistance(){
		PlayerPrefs.SetFloat ("Distance", 0);
	}

	public void setDistanceFull(){
		PlayerPrefs.SetFloat ("Distance", 50);
	}

	public void unlockLevel(){
		GameObject lockGO = GameObject.Find ("LockA4_button");
		if ( PlayerPrefs.GetFloat ("Distance") >= 50f) {
			lockGO.SetActive (false);
		}
	}
}
