using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	int enemyChoice;
	int timeLimit;
	float gameOverTime;
	float flashTime;
	bool gameOver;
	bool captured;
	bool deleted = false;
	public UILabel infoLog;
	public float spawnTime;
	public List<GameObject> Aenemies;
	public List<GameObject> Benemies;
	public List<GameObject> Cenemies;
	public List<GameObject> capturedEnemies;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	public Texture2D noise;
	public Texture2D spawnedNoise;
	public GameObject capturedLabel;
	public GameObject capturedScreen;
	public GameObject deletedWarning;
	public StatsController sc;

	//Audio==============
	public AudioSource staticSound;
	public AudioSource cameraOff;




	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		infoLog = GameObject.Find("InfoLog").GetComponent<UILabel>();
		timeLimit = Random.Range(5,10);
		sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		GameObject.Find("Screen").GetComponent<CameraObscura>().startCam();
		infoLog.text = "Obscura starting...";
		infoLog.text += "\nNo Voiders detected nearby.";
		deletedWarning.SetActive(false);
		sc.getMonstersStats();
	}

	public void resetSpawn(){
		spawnTime = 0;
		if(GameObject.FindWithTag("Enemy") != null){
			GameObject.FindWithTag("Enemy").SetActive(false);
		}
	}
	void spawningEnemy(){
		spawnTime += Time.deltaTime;
		if(spawnTime >= timeLimit && !GameObject.FindWithTag("Enemy") && !gameOver){
			staticSound.Play();
			Handheld.Vibrate();
			GameObject.Find("Main Camera").GetComponent<NightVisionEffect>().nightVisionNoise = spawnedNoise;

			switch(sc.activeLens){
			case "GrayScale":
				switch(sc.grayScaleLens.focus){
				case 0:	enemyChoice = Random.Range(0,2);break;
				case 1:	enemyChoice = Random.Range(0,2);break;
				case 2:	enemyChoice = Random.Range(0,3);break;
				case 3:	enemyChoice = Random.Range(0,4);break;
				case 4:	enemyChoice = Random.Range(0,5);break;
				case 5:	enemyChoice = Random.Range(0,5);break;
				}
				Cenemies[enemyChoice].SetActive(true);
				break;
			case "Sepia":
				switch(sc.sepiaLens.focus){
				case 0:	enemyChoice = Random.Range(0,2);break;
				case 1:	enemyChoice = Random.Range(0,2);break;
				case 2:	enemyChoice = Random.Range(0,3);break;
				case 3:	enemyChoice = Random.Range(0,4);break;
				case 4:	enemyChoice = Random.Range(0,5);break;
				case 5:	enemyChoice = Random.Range(0,5);break;
				}
				Benemies[enemyChoice].SetActive(true);
				break;
			case "NightVision":
				switch(sc.nightVLens.focus){
				case 0:	enemyChoice = Random.Range(0,2);break;
				case 1:	enemyChoice = Random.Range(0,2);break;
				case 2:	enemyChoice = Random.Range(0,3);break;
				case 3:	enemyChoice = Random.Range(0,4);break;
				case 4:	enemyChoice = Random.Range(0,5);break;
				case 5:	enemyChoice = Random.Range(0,5);break;
				}
				Aenemies[enemyChoice].SetActive(true);
				break;
			}
			enemyChoice = Random.Range(0,5);

			//enemies[equiped][enemyChoice].SetActive(true);
			//Choosing Enemy

			//Debug.Log("Enemy name : " + GameObject.FindWithTag("Enemy").name);


			checkingEnemy();
			spawnTime = 0;
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
				Application.LoadLevel("LevelSelection");
			}
			if(captured && Input.GetMouseButtonDown(0)){
				capturedLabel.SetActive(false);
				capturedScreen.SetActive(true);
				gameOver = true;
			}
		}
		else{
			spawningEnemy();
		}
	}
	void checkingEnemy(){
		foreach(GameObject obj in capturedEnemies){
			if(obj.name == "C" + GameObject.FindWithTag("Enemy").name){
				obj.SetActive(true);
			}
			else{
				obj.SetActive(false);
			}
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
			cameraOff.Play ();
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
