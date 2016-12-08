using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	float timer;
	int step;
	public UILabel talk;
	public GameObject chat;

	public GameObject markFocus;
	public GameObject markBattery;
	public GameObject markMenu;
	public GameObject markProgress;
	public GameObject markLog;
	public GameObject markHP;


	// Use this for initialization
	void Start () {
		timer = 0.0f;
		step = 0;
		chat.SetActive(false);
		markFocus.SetActive(false);
		markBattery.SetActive(false);
		markMenu.SetActive(false);
		markProgress.SetActive(false);
		markLog.SetActive(false);
		markHP.SetActive(false);
		Tutorial1();
	}

	public void gameOverWarning(){
		Time.timeScale = 0;
		step = 25;
		chat.SetActive(true);
		talk.text = "When the battery runs out, the Obscura will shut down.";
	}
	void Tutorial1(){

		switch(step){
		case 0:
			GetComponent<AudioSource>().Play ();
			chat.SetActive(true);
			talk.text = "Before I teach you how to operate Obscura, there are a few thing that you might need to know.";
			step++;
			break;
		case 1:
			GetComponent<AudioSource>().Play ();
			markBattery.SetActive(true);
			talk.text = "This is the battery of Obscura, it will depletes over time.";
			step++;
			break;
		case 2:
			GetComponent<AudioSource>().Play ();
			talk.text = "If the battery runs out, the Obscura will shut down automatically.";
			step++;
			break;
		case 3:
			GetComponent<AudioSource>().Play ();
			markBattery.SetActive(false);
			markMenu.SetActive(true);
			talk.text = "The left button is the 'Back' button, which brings you back to the Main Menu of Obscura.";
			step++;
			break;
		case 4:
			GetComponent<AudioSource>().Play ();
			talk.text = "We will not do that for now.";
			step++;
			break;
		case 5:
			GetComponent<AudioSource>().Play ();
			talk.text = "The camera icon is the 'Equip' button, which enables you to change the Obscura lenses.";
			step++;
			break;
		case 6:
			GetComponent<AudioSource>().Play ();
			talk.text = "For now, you only have one lens which is 'GrayScale' lens.";
			step++;
			break;
		case 7:
			GetComponent<AudioSource>().Play ();
			talk.text = "Note that different lenses will reveal different kinds of Voiders.";
			step++;
			break;
		case 8:
			GetComponent<AudioSource>().Play ();
			markMenu.SetActive(false);
			markLog.SetActive(true);
			talk.text = "At the bottom right corner, here lies the Information Log.";
			step++;
			break;
		case 9:
			GetComponent<AudioSource>().Play ();
			talk.text = "Information Log will keep track of what is happening. Pay attention to the Information Log because it might just help you in way.";
			step++;
			break;
		case 10:
			markLog.SetActive(false);
			markProgress.SetActive(true);
			talk.text = "This Capture Bar will show you how close are you in capturing the Voiders. It will show you what state are you in as well.";
			step++;
			break;
		case 11:
			GetComponent<AudioSource>().Play ();
			markProgress.SetActive(false);
			markFocus.SetActive(true);
			talk.text = "This big square at the center of the screen is the focus of Obscura.";
			step++;
			break;
		case 12:
			GetComponent<AudioSource>().Play ();
			talk.text = "In order to capture the Voiders, the Voider must be in the focus.";
			step++;
			break;
		case 13:
			GetComponent<AudioSource>().Play ();
			talk.text = "There are a few capturing methods to be noted, such as...";
			step++;
			break;
		case 14:
			GetComponent<AudioSource>().Play ();
			talk.text = "Tapping the Voider repeatedly until the Capture Bar is depleted.";
			step++;
			break;
		case 15:
			GetComponent<AudioSource>().Play ();
			talk.text = "There are still ways to be discovered to capture Voiders. You just need to discover that yourself.";
			step++;
			break;
		case 16:
			GetComponent<AudioSource>().Play ();
			markFocus.SetActive(false);
			markHP.SetActive(true);
			talk.text = "This is your Health Point. When it reaches 0, you will die and might loses some data.";
			step++;
			break;
		case 17:
			GetComponent<AudioSource>().Play ();
			talk.text = "So, be careful of aggresive Voiders. When the screen starts flashing, avoid eye contact with Voiders to avoid being attacked.";
			step++;
			break;
		case 18:
			GetComponent<AudioSource>().Play ();
			markHP.SetActive(false);
			talk.text = "Now, let's capture your first Voiders shall we?";
			step++;
			break;
		case 19:
			GetComponent<AudioSource>().Play ();
			chat.SetActive(false);
			timer += 1.0f;
			Time.timeScale  = 1;
			step++;
			break;
		case 25:
			GetComponent<AudioSource>().Play ();
			talk.text = "But, for now, i will recharge it for you.";
			GameObject.Find ("Battery").GetComponent<BatteryLife>().battery = 1;
			step++;
			break;
		case 26:
			GetComponent<AudioSource>().Play ();
			chat.SetActive(false);
			timer += 1.0f;
			Time.timeScale  = 1;
			step++;
			break;

		default:
			break;
			
		}
		
	}
	// Update is called once per frame
	void Update () {
		if(GameObject.Find ("Battery").GetComponent<BatteryLife>().battery <= 0.3f){
			gameOverWarning();

		}
		timer+= Time.deltaTime;
		if(timer>=1 && timer <=2)
			Time.timeScale = 0;
		if(Input.GetMouseButtonDown(0) && timer >= 1){
			Tutorial1();
		}
	}
}
