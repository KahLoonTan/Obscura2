using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialController : MonoBehaviour {
	int enemyChoice;
	public int equiped;
	int timeLimit;
	float gameOverTime;
	float flashTime;
	bool gameOver;
	bool captured;
	public UILabel infoLog;
	public float spawnTime;
	public GameObject firstEnemy;
	public GameObject capturedEnemy;
	
	public Texture2D noise;
	public Texture2D spawnedNoise;
	public GameObject capturedLabel;
	public GameObject capturedScreen;
	public StatsController sc;

	public AudioSource staticSound;
	// Use this for initialization
	void Start () {
		firstEnemy.SetActive(false);
		infoLog = GameObject.Find("InfoLog").GetComponent<UILabel>();
		timeLimit = Random.Range(5,10);
		sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		GameObject.Find("Screen").GetComponent<CameraObscura>().startCam();
		infoLog.text = "Obscura starting...";
		infoLog.text += "\nNo Voiders detected nearby.";
		sc.getMonstersStats();
	}

	void spawningEnemy(){
		spawnTime += Time.deltaTime;
		if(spawnTime >= timeLimit && !GameObject.FindWithTag("Enemy") && !gameOver){
			GameObject.Find("Main Camera").GetComponent<NightVisionEffect>().nightVisionNoise = spawnedNoise;
			staticSound.Play();
			Handheld.Vibrate();
			if(firstEnemy != null)
			firstEnemy.SetActive(true);
			capturedEnemy.SetActive(true);
			infoLog.text += "\nA Voider is nearby.";
		}
		if(GameObject.Find("Main Camera").GetComponent<NightVisionEffect>().nightVisionNoise == spawnedNoise){
			flashTime++;
		}
		if(flashTime >= 10){
			GameObject.Find("Main Camera").GetComponent<NightVisionEffect>().nightVisionNoise = noise;
		}
	}
	// Update is called once per frame
	void Update () {

		if(gameOver || captured){
			gameOverTime ++;
			if( gameOver && Input.GetMouseButtonDown(0) && gameOverTime>=60){
				Application.LoadLevel("MainMenu");
			}
			if(captured && Input.GetMouseButtonDown(0)){
				capturedLabel.SetActive(false);
				capturedScreen.SetActive(true);
				gameOver = true;
			}
		}
		else{
			Debug.Log("Spawning");
			spawningEnemy();
		}
	}
	public void triggerCaptured(){
		captured = true;
		infoLog.text += "\nVoider captured!";
		if(GameObject.Find("Screen") != null){//stop camera
			GameObject.Find("Screen").GetComponent<CameraObscura>().stopCam();
		}
		capturedLabel.SetActive(true); 
		Time.timeScale = 0;
		//sc.capturedMonster(GameObject.FindWithTag("Enemy").name);
		//GameObject.Find("Directional light").light.color = Color.black;
		if(GameObject.FindWithTag("Enemy")){
			GameObject.FindWithTag("Enemy").SetActive(false);
		}
	}
	public void triggerGameOver(){
		if(!gameOver){
			infoLog.text += "\nObscura ran out of battery...";
			infoLog.text += "\nShutting down...";
		}
		gameOver = true;
		
		if(GameObject.Find("Screen") != null){//stop camera
			GameObject.Find("Screen").GetComponent<CameraObscura>().stopCam();
		}
		GameObject.Find("Main Camera").GetComponent<MyGyro>().enabled = false;
		capturedLabel.GetComponent<UILabel>().text = "Game Over";
		capturedLabel.SetActive(true);
		GameObject.Find("Directional light").GetComponent<Light>().color = Color.black;
		if(GameObject.FindWithTag("Enemy")){
			GameObject.FindWithTag("Enemy").SetActive(false);
		}
	}
}
