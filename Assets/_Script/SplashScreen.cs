using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	float timer;
	public float wait = 2.0f;
	// Use this for initialization
	void Start () {

	}
	
	void Update(){
		timer += Time.deltaTime;

		if(timer >= wait){
			if(PlayerPrefs.GetInt("FirstTime") == 0){
				Application.LoadLevel("Intro");
			}else{
				Application.LoadLevel("MainMenu");
			}
		}
	}
}
