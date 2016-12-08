using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public enum Difficulty{Passive,Neutral,Aggresive}
	public Difficulty diff;
	public GameObject warning;
	private int attackRate;
	PlayerController pc;
	int choice;
	private float timer;
	// Use this for initialization
	void Start () {
		attackRate = 100;
		pc = GameObject.Find("Screen").GetComponent<PlayerController>();
		warning.SetActive(false);
	}

	void OnTriggerEnter(Collider other){
		choice = 50;
	}
	void OnTriggerStay(Collider other){
		switch(diff){
		case Difficulty.Passive:
			break;

		case Difficulty.Neutral:
			//Debug.Log("Choice : " + choice);
			if(choice == 1){
				GameObject.Find ("Directional light").GetComponent<TweenColor>().enabled = true;
				warning.SetActive(true);
				timer += Time.deltaTime;
				if(timer >= 2.0f){
					choice = -1;
				}
			}else if(choice == -1){
				Handheld.Vibrate();
				GameObject temp = Resources.Load<GameObject>("Damaged");
				NGUITools.AddChild(GameObject.Find("Camera"),temp);
				pc.updateHP(1);
				timer = 0;
				choice = 1;
			}else{
				choice = Random.Range(0,(attackRate+this.GetComponent<DestroyByContact>().healthPoints));
			}
			break;

		case Difficulty.Aggresive:
			if(choice == 1){
				GameObject.Find ("Directional light").GetComponent<TweenColor>().enabled = true;
				warning.SetActive(true);
				timer += Time.deltaTime;
				if(timer >= 1.5f){
					choice = -1;
				}
				
			}else if(choice == -1){
				Handheld.Vibrate();
				GameObject temp = Resources.Load<GameObject>("Damaged");
				NGUITools.AddChild(GameObject.Find("Camera"),temp);
				pc.updateHP(2);
				timer = 0;
				choice = 1;
			}else{
				choice = Random.Range(0,(attackRate+this.GetComponent<DestroyByContact>().healthPoints)-30);
			}
			break;
		}
	}
	void OnTriggerExit(Collider other){
		if(choice == 1){
			if(GameObject.Find("Flare(Clone)")){
				Destroy(GameObject.Find("Flare(Clone)"));
			}
			if(GameObject.Find("Damaged(Clone)") != null)
			Destroy(GameObject.Find("Damaged(Clone)").gameObject);
			warning.SetActive(false);
			GameObject.Find ("Directional light").GetComponent<Light>().color = Color.white;
			GameObject.Find ("Directional light").GetComponent<TweenColor>().enabled = false;
		}
	}
	void checkingBehaviour(){

	}
	// Update is called once per frame
	void Update () {
		checkingBehaviour();
	}
}
