using UnityEngine;
using System.Collections;

public class Initiation : MonoBehaviour {
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("FirstTime") == 0){

			PlayerPrefs.SetInt("PlayerHP",3);
			PlayerPrefs.SetInt("PlayerLevel",1);
			PlayerPrefs.SetInt("EXP",0);
			PlayerPrefs.SetInt("Coins",200);

			PlayerPrefs.SetString("ActiveLens","GrayScale");
			PlayerPrefs.SetInt("monster1",0);
			PlayerPrefs.SetInt("monster2",0);
			PlayerPrefs.SetInt("monster3",0);
			PlayerPrefs.SetInt("monster4",0);
			PlayerPrefs.SetInt("monster5",0);
			PlayerPrefs.SetInt("monster6",0);
			PlayerPrefs.SetInt("monster7",0);
			PlayerPrefs.SetInt("monster8",0);
			PlayerPrefs.SetInt("monster9",0);

			PlayerPrefs.SetInt("Owned2",0);
			PlayerPrefs.SetInt("Owned3",0);
			PlayerPrefs.SetInt("Battery1", 1);
			PlayerPrefs.SetInt("Focus1", 1);
			PlayerPrefs.SetInt("Battery2", 1);
			PlayerPrefs.SetInt("Focus2", 1);
			PlayerPrefs.SetInt("Battery3", 1);
			PlayerPrefs.SetInt("Focus3", 1);

		
		}else{

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
