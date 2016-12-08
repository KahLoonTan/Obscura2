using UnityEngine;
using System.Collections;

public class OptionsNavigation : MonoBehaviour {
	public GameObject option;
	// Use this for initialization
	void Start () {
		option.SetActive(false);
	}

	void ToggleOption(){
		if(option.activeInHierarchy){
			option.SetActive(false);
		}else{
			option.SetActive(true);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
