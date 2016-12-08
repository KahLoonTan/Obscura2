using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int playerHP = 3;
	public UILabel HPLabel;
	private int maxPlayerHP;
	public int experience;
	private float timer;
	public bool tapTime;
	public bool tapped = false;
	public bool inRange = false;
	public bool holding = false;
	public GameController gc;
	public UIProgressBar healthBar;
	private GameObject capturedEnemy;
	public NightVisionEffect night;
	public Texture2D normalTexture;
	public Texture2D capturedTexture;
	public GameObject targetIn;
	public GameObject targetOut;
	public float targetTime = 0;
	public bool aiming = false;
	public NoiseEffect noise;
	private bool randomDeleted = false;
	public GameObject tapInstruc;
	public GameObject holdInstruc;
	public GameObject timeInstruc;

	//Audio
	AudioSource capturedSound;
	AudioSource damagedSound;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		maxPlayerHP = PlayerPrefs.GetInt("PlayerHP");
		playerHP = maxPlayerHP;
		HPLabel.text = playerHP + " / " + maxPlayerHP;
		GameObject.Find ("Status").GetComponent<UILabel> ().text = "Searching...";
		noise.enabled = false;
		capturedSound = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().capturedSFX;
		damagedSound = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().attackedSFX;
	}

	
	// Update is called once per frame
	void Update () {
		if(playerHP <= 0){
			playerHP = 0;
			healthBar.value = (float)playerHP/maxPlayerHP;
			HPLabel.text = playerHP + " / " + maxPlayerHP;
			if(randomDeleted == false){
				GameObject.Find("PlayerStats").GetComponent<StatsController>().deleteRandom();
				randomDeleted = true;
				gc.deletedWarning.SetActive(true);
			}
			gc.triggerGameOver();
		}
		if(aiming){
			targetTime += Time.deltaTime;
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
		}


	}
	public void updateHP(int damage){
		damagedSound.Play();
		playerHP -= damage;
		healthBar.value = (float)playerHP/maxPlayerHP;
		HPLabel.text = playerHP + " / " + maxPlayerHP;
	}
	public void addEXP(int num){
		experience += num;
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
			switch(GameObject.Find("PlayerStats").GetComponent<StatsController>().activeLens){
			case "GrayScale":
				gc.infoLog.text += "\nTap on the target!";
				tapInstruc.SetActive(true);
				break;
			case "Sepia":
				gc.infoLog.text += "\nHold the focus on the target!";
				holdInstruc.SetActive(true);
				break;
			case "NightVision":
				gc.infoLog.text += "\nTime the capture accurately!";
				timeInstruc.SetActive(true);
				break;
			}
			if(other.GetComponent<DestroyByContact>().type == DestroyByContact.CapMethod.hold){
				tapped = true;
			}
			if(other.GetComponent<DestroyByContact>().type == DestroyByContact.CapMethod.time){
				aiming = true;
				targetIn.SetActive(true);
				targetOut.SetActive(true);
				targetTime = 0;
			}
		}

	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Enemy") {
			GameObject.Find ("Status").GetComponent<UILabel> ().text = "Capturing...";
			inRange = true;
		
		if(tapped && inRange){
				capturedEnemy = other.gameObject;
				capturedEnemy.GetComponent<DestroyByContact>().checkEnemyHealth();
			}
		}
	}

	void OnTriggerExit(Collider other){
		tapped = false;
		if(GameObject.Find("Flare(Clone)") != null){
			Destroy(GameObject.Find("Flare(Clone)"));
		}
		switch(GameObject.Find("PlayerStats").GetComponent<StatsController>().activeLens){
			case "GrayScale":
				tapInstruc.SetActive(false);
				break;
			case "Sepia":
				holdInstruc.SetActive(false);
				break;
			case "NightVision":
				timeInstruc.SetActive(false);
				break;
		}
		GameObject.Find ("Status").GetComponent<UILabel> ().text = "Searching...";
		if (other.tag == "Enemy") {
			noise.enabled = false;
			inRange = false;
			night.nightVisionNoise = normalTexture;
			if(GameObject.Find("!") != null)
				GameObject.Find("!").SetActive(false);
			if(GameObject.Find("TargetOut") != null){
				targetIn.SetActive(false);
				targetOut.SetActive(false);
			}
		}

	}

}
