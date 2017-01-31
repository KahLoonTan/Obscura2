using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {
	public GameObject posA;
	public GameObject posB;


	public GameObject obj;
	public GameObject instruction;
	bool canSpawn = false;
	Vector3 spawnPos;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnObject(){
		int number = Random.Range (0, 2);

		if (number == 0) {
			spawnPos = posA.transform.position;
		} else if (number == 1) {
			spawnPos = posB.transform.position;
		}

		Instantiate (obj, spawnPos, obj.gameObject.transform.rotation);
	}

	public void Invoking(){
		InvokeRepeating ("SpawnObject", 1, 3);
	}
}
