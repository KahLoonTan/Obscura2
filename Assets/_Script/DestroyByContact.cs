using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	//the type of method to capture monsters
	public enum CapMethod{tap,hold,time}
	public CapMethod type ;

	public int healthPoints = 10;
	private int maxHP;
	private UIProgressBar healthBar;
	private PlayerController player;
	private StatsController sc;

	private int rand;
	//Audio
	public AudioSource tapSFX;
	public AudioSource holdSFX;
	public AudioSource timingSFX;
	public AudioSource attackedSFX;
	// Use this for initialization
	void Start () {
		tapSFX = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().tapSFX;
		holdSFX = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().holdSFX;
		timingSFX = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().timingSFX;
		attackedSFX = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().attackedSFX;
		maxHP = healthPoints;
		player = GameObject.Find("Screen").GetComponent<PlayerController>();
		healthBar = GameObject.Find("ProgressBar").GetComponent<UIProgressBar>();
		sc = GameObject.Find ("PlayerStats").GetComponent<StatsController>();
		healthBar.value = (float)healthPoints/maxHP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void checkEnemyHealth(){
		//if TAP
		if(type == CapMethod.tap){
			tapSFX.Play();
			GameObject temp = Resources.Load<GameObject>("Burst");
			GameObject temp2 = GameObject.FindWithTag("Enemy").gameObject;
			NGUITools.AddChild(temp2,temp);
			healthPoints--;
			healthBar.value = (float)healthPoints/maxHP;
			player.tapped = false;
			player.inRange = false;
		}

		//if Hold
		if(type == CapMethod.hold){
			holdSFX.Play ();
			player.tapped = true;
			if(GameObject.Find("Flare(Clone)")== null){
				GameObject temp = Resources.Load<GameObject>("Flare");
				GameObject temp2 = GameObject.FindWithTag("Enemy").gameObject;
				NGUITools.AddChild(temp2,temp);
			}
			healthPoints--;
			healthBar.value = (float)healthPoints/maxHP;
		}


		//if TIME
		if(type ==CapMethod.time){
			Debug.Log(player.targetTime);
			if(player.targetTime >= 2.0f && player.targetTime<=3.5f){
				timingSFX.Play();
				SendMessage("OnClick");
				healthPoints--;
				healthBar.value = (float)healthPoints/maxHP;
				player.targetTime = 0;
				player.tapped = false;
				player.inRange = false;
			}else{
				attackedSFX.Play();
				player.updateHP(1);
				GameObject temp = Resources.Load<GameObject>("Damaged");
				NGUITools.AddChild(GameObject.Find("Camera"),temp);
				player.targetTime = 0;
				player.tapped = false;
				player.inRange = false;
				rand = Random.Range(0,3);
				if(rand == 1){
					player.targetIn.SetActive(false);
					player.targetOut.SetActive(false);
					this.gameObject.SetActive(false);
					healthBar.value = 1.0f;
				}
			}

		}
		Debug.Log("HP:" + healthPoints);
		if(healthPoints <= 0){
			player.capturingEffect();
			GameObject.Find ("Directional light").GetComponent<TweenColor>().enabled = false;
			if(GameObject.Find("!") != null)
				GameObject.Find("!").SetActive(false);
			if(GameObject.Find("Damaged(Clone)") != null)
				Destroy(GameObject.Find("Damaged(Clone)").gameObject);
			if(GameObject.Find("TargetOut") != null){
				player.targetIn.SetActive(false);
				player.targetOut.SetActive(false);
			}
			sc.capturedMonster(this.name);
			sc.lootMonster(this.name);
			Destroy(this.gameObject);
		}
	}


}
