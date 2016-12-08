using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {
	public float MoveSpeed = 1;
	private GameObject enemy;
	private float timer;
	private bool hit = false;
	//PlayerController pc;
	// Use this for initialization
	void Start () {
		hit = false;
		//pc = GameObject.Find ("Screen").GetComponent<PlayerController>();
		enemy = GameObject.FindWithTag ("Enemy");
	}
	void OnTriggerStay(Collider other){
		if(other.tag == "Enemy"){
			timer += Time.deltaTime;
			if(hit){
				other.GetComponent<DestroyByContact>().checkEnemyHealth();
				Destroy(this.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			hit = true;
		}
		if(hit){
			timer += Time.deltaTime;
		}if(timer >= 1){
			GameObject.Find("GameController").GetComponent<GameController>().triggerGameOver();
			Destroy(this.gameObject);
		}
		transform.LookAt(enemy.transform);
		transform.position += transform.forward*MoveSpeed*Time.deltaTime;
	}
}
