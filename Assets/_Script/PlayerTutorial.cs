using UnityEngine;
using System.Collections;

public class PlayerTutorial : MonoBehaviour {
	private float timer;
	public bool tapTime;
	public int playerHP = 3;
	public UILabel HPLabel;
	int maxPlayerHP;
	public UIProgressBar healthBar;
	public bool tapped =true;
	public bool inRange =false;
	public bool holding = false;
	public TutorialController gc;
	private GameObject capturedEnemy;
	public NightVisionEffect night;
	public Texture2D normalTexture;
	public Texture2D capturedTexture;
	public GameObject target;
	public NoiseEffect noise;

	AudioSource capturedSound;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		maxPlayerHP = PlayerPrefs.GetInt("PlayerHP");
		playerHP = maxPlayerHP;
		HPLabel.text = playerHP + " / " + maxPlayerHP;
		capturedSound = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().capturedSFX;
		GameObject.Find ("Status").GetComponent<UILabel> ().text = "Searching...";
	}
	
	
	// Update is called once per frame
	void Update () {
		if(playerHP <= 0){
			GameObject.Find("TutorialController").GetComponent<Tutorial>().gameOverWarning();
			playerHP = 3;
			HPLabel.text = playerHP + " / " + maxPlayerHP;
		}
		checkingCaptured();
		if(Input.GetMouseButtonDown(0))
		{
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit) && (hit.collider.tag == "Enemy"))
			{   
				tapped = true;
			}else
				tapped = false;
			
			//Debug.Log(tapped);
		}
		
		
	}
	public void capturingEffect(){
		capturedSound.Play ();
		if(night.nightVisionNoise == normalTexture){
			night.nightVisionNoise = capturedTexture;
			
		}else{
			night.nightVisionNoise = normalTexture;
		}
	}
	void checkingCaptured(){
		if(night.nightVisionNoise == capturedTexture){
			
			timer = timer +2;
			
			if(timer >= 2){
				GameObject.Find ("Status").GetComponent<UILabel> ().text = "";
				capturingEffect();
				gc.triggerCaptured();
			}
			
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "EnemyRange"){
			Handheld.Vibrate();
			noise.enabled = true;
			Debug.Log("Entering");
			gc.infoLog.text += "\nVoider detected!";
			other.gameObject.SetActive(false);
		}
		if (other.tag == "Enemy") {
			//Debug.Log("Got Enemy");
			switch(gc.equiped){
			case 0:
				gc.infoLog.text += "\nTap on the target!";
				break;
			case 1:
				gc.infoLog.text += "\nHold the focus on the target!";
				break;
			case 2:
				gc.infoLog.text += "\nTime thplayerHPplayerHPe capture accurately!";
				break;
			}
			GameObject.Find ("Status").GetComponent<UILabel> ().text = "Entering...";
			if(other.GetComponent<DestroyTutorial>().type == DestroyTutorial.CapMethod.time){
				target.SetActive(true);
			}
		}
		
	}
	
	void OnTriggerStay(Collider other){
		if (other.tag == "Enemy") {
			GameObject.Find ("Status").GetComponent<UILabel> ().text = "Capturing...";
			inRange = true;
			
			if(tapped && inRange){
					capturedEnemy = other.gameObject;
					capturedEnemy.GetComponent<DestroyTutorial>().checkEnemyHealth();
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		GameObject.Find ("Status").GetComponent<UILabel> ().text = "Searching...";
		if (other.tag == "Enemy") {
			noise.enabled = false;
			inRange = false;
			night.nightVisionNoise = normalTexture;

			
		}
	}
	
}
