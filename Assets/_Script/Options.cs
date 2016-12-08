using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	public GameObject soundOn;
	public GameObject soundOff;

	// Use this for initialization
	void Start () {
		if(AudioListener.volume == 1){
			soundOn.SetActive(true);
			soundOff.SetActive(false);
		}else{
			soundOn.SetActive(false);
			soundOff.SetActive(true);
		}
	}

	void toggleSound(){
		if(AudioListener.volume == 0){
			AudioListener.volume = 1;
			soundOn.SetActive(true);
			soundOff.SetActive(false);
		}else{
			AudioListener.volume = 0;
			soundOn.SetActive(false);
			soundOff.SetActive(true);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
