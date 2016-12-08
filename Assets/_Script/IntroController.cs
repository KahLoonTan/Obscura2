using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour {
	public UILabel talk;
	private int step = -1;
	private bool ready = false;
	private float timer;

	public GameObject title;
	public GameObject prof;
	public GameObject chat;
	// Use this for initialization
	void Start () {
		title.SetActive(true);
		prof.SetActive(false);
		chat.SetActive(false);
		ready= false;
		timer = 0.0f;
	}
	void nextTalk(){
		GetComponent<AudioSource>().Play ();
		switch(step){
		case -1:
			title.SetActive(false);
			prof.SetActive(true);
			chat.SetActive(true);
			step++;
			break;
		case 0:
			talk.text = "Greetings, if you are listening to this recording, it means that Me, Professor Steve is no longer in the same realm as you.";
			step++;
			break;
		case 1:
			talk.text = "I should be in the Void Realm by now studying Voiders, the unknown beings that exist only in the Void Realm but not in the Human Realm.";
			step++;
			break;
		case 2:
			talk.text = "I have made this recording to guide you to help me complete the study of the Voiders.";
			step++;
			break;
		case 3:
			talk.text = "This device you are holding is a special camera called Obscura that can reveals the Voiders.";
			step++;
			break;
		case 4:
			talk.text = "A VoidBook comes with Obscura to record the data of the Voiders.";
			step++;
			break;
		case 5:
			talk.text = "The VoidBook somehow lost most of it's data after I entered the Void.";
			step++;
			break;
		case 6:
			talk.text = "By using these two equipments, Capture the appearance of the Voiders and record their behaviours in the VoidBook.";
			step++;
			break;
		case 7:
			talk.text = "Let us begin by learning how to use the Obscura, shall we?";
			step++;
			break;
		case 8:
			Application.LoadLevel("Tutorial");
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= 3){
			ready = true;
		}
		if(ready && Input.GetMouseButtonDown(0)){
			nextTalk();
		}
	}
}
