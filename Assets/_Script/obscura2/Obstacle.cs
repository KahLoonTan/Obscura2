using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	int speed;
	int destroyDelay;

	void Start() {
		speed = 5;
		destroyDelay = 5;
	}
	void Update() {
		Vector3 move = new Vector3 (0, 0, -speed);
		transform.position += move * Time.deltaTime;
		Destroy (gameObject, destroyDelay);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.transform.position = new Vector3 (0, 0, -4);
			Destroy (gameObject);
		}
	}


}
