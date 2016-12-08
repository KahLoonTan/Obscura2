using UnityEngine;
using System.Collections;

public class FirstTimeMainMenu : MonoBehaviour {
	public GameObject block;
	public GameObject chat;
	public UILabel talk;

	private Collider diary;
	private Collider upgrade;
	float timer = 0;
	int step;
	// Use this for initialization
	void Start () {
		timer=0;
		step =0;
		block.SetActive(false);
		chat.SetActive(false);
		diary = GameObject.Find ("Diary").GetComponent<Collider>();
		upgrade = GameObject.Find("Cam").GetComponent<Collider>();
		checkFirstTime();
	}
	void checkFirstTime(){
		if(PlayerPrefs.GetInt("FirstTime") == 0){
			diary.enabled  =false;
			upgrade.enabled = false;
			block.SetActive(true);
			chat.SetActive(true);
			nextTalk();
		}
	}
	void nextTalk(){
		GetComponent<AudioSource>().Play();
		switch(step){
		case 0:
			talk.text = "Congratulations! You have captured your first Voider!";
			step++;
			break;
		case 1:
			talk.text = "Now, you can check the Voiders you have captured in the VoidBook";
			step++;
			break;
		case 2:
			talk.text = "Every Voider you capture will earn you coins. These coins can be used to upgrade the Obscura.";
			step++;
			break;
		case 3:
			talk.text = "Upgrading the Obscura is crucial in order to capture more Voiders.";
			step++;
			break;
		case 4:
			talk.text = "You can even unlock new lenses when you capture enough Voiders. New lenses will reveal new kinds of Voiders. Keep that in mind.";
			step++;
			break;
		case 5:
			talk.text = "Tap on the Focus to start the Obscura in order to capture more Voiders.";
			step++;
			break;
		case 6:
			talk.text = "Now that you know everything you need to know, capture and complete the VoidBook with your best capabilites.";
			step++;
			break;
		case 7:
			talk.text = "When you captured enough Voiders and understand the Void well enough, we might just met again.";
			step++;
			break;
		default:
			PlayerPrefs.SetInt("FirstTime",1);
			PlayerPrefs.SetInt("PlayerHP",4);
			PlayerPrefs.SetInt("Coins",225);
			diary.enabled = true;
			upgrade.enabled = true;
			block.SetActive(false);
			chat.SetActive(false);
			break;
		}
	}
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			checkFirstTime();
		}
	}
}
