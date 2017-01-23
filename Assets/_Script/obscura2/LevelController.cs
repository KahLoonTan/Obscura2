using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	public float distance=0f;
	void Start () {
		//PlayerPrefs.SetFloat ("Distance", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setDistance(float d){
		float currDistance = PlayerPrefs.GetFloat ("Distance");
		PlayerPrefs.SetFloat ("Distance", currDistance+d);
	}
}
