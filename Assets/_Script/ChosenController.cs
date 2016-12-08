using UnityEngine;
using System.Collections;

public class ChosenController : MonoBehaviour {
	private DiaryController dc;
	// Use this for initialization
	void Start () {
		dc = GameObject.Find("DiaryController").GetComponent<DiaryController>();
	}
	void choose(){
		if(this.GetComponent<UILabel>().text != "?????"){
			GetComponent<AudioSource>().Play();
			dc.setChosen(this.name);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
