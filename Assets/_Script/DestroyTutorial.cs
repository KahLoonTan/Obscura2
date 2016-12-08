using UnityEngine;
using System.Collections;

public class DestroyTutorial : MonoBehaviour {
	//the type of method to capture monsters
	public enum CapMethod{tap,hold,time}
	public CapMethod type ;
	
	public int healthPoints = 10;
	private int maxHP;
	private UIProgressBar healthBar;
	private PlayerTutorial player;
	private StatsController sc;

	public AudioSource tapSFX;
	public AudioSource attackedSFX;
	// Use this for initialization
	void Start () {
		tapSFX = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().tapSFX;
		attackedSFX = GameObject.Find("AudioCenter").GetComponent<AudioCenter>().attackedSFX;
		maxHP = healthPoints;
		player = GameObject.Find("Screen").GetComponent<PlayerTutorial>();
		healthBar = GameObject.Find("ProgressBar").GetComponent<UIProgressBar>();
		sc = GameObject.Find ("PlayerStats").GetComponent<StatsController>();
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

		if(healthPoints <= 0){
			Debug.Log("GameOver");
			player.capturingEffect();
			GameObject.Find ("Directional light").GetComponent<TweenColor>().enabled = false;
			if(GameObject.Find("!") != null)
				GameObject.Find("!").SetActive(false);
			if(GameObject.Find("Damaged(Clone)") != null)
				Destroy(GameObject.Find("Damaged(Clone)").gameObject);
			sc.capturedMonster(this.name);
			sc.lootMonster(this.name);
			Destroy(this.gameObject);
		}
	}
	
	
}
