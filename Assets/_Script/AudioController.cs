using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	public AudioSource bgm1;
	public AudioSource bgm2;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "Gameplay"){
			if(bgm1.isPlaying){
				bgm1.Pause();
				bgm2.Play ();
			}
		}
		if(Application.loadedLevelName == "MainMenu"){
			if(GetComponent<AudioSource>().isPlaying){

			}else{
				bgm2.Pause();
				bgm1.Play ();
			}
		}
	}
}
