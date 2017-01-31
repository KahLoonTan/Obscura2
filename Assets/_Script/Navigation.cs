using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	void restart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void mainMenu()
	{
		GameObject.Find("Screen").GetComponent<CameraObscura>().stopCam();
		Application.LoadLevel("MainMenu");
	}
	public void back(){
		Application.LoadLevel("MainMenu");
	}
	public void gameStart(){
		Application.LoadLevel("Gameplay");
	}
	public void openShop(){
		Application.LoadLevel("Shop");
	}
	public void diary(){
		Application.LoadLevel("Diary");
	}
	public void levelSelection(){
		Application.LoadLevel ("LevelSelection");
	}
	public void libraryLevel(){
		Application.LoadLevel ("Library");
	}
	public void forestLevel(){
		Application.LoadLevel ("DarkForest");
	}
	public void cityLevel(){
		//Application.LoadLevel ("ForgottenTown");
		SceneManager.LoadScene ("ForgottenTown");
	}
}
