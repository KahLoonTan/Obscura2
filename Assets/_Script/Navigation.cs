using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
	// Use this for initialization
	void Start () {

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
	public void game(){
		Application.LoadLevel ("GameLevel");
	}
}
