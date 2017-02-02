using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {
	public GameObject posA;
	public GameObject posB;
	public GameObject incomingA;
	public GameObject incomingB;

	public GameObject obj;
	public GameObject instruction;
	public float spawnTime;
	bool canSpawn = false;
	Vector3 spawnPos;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator SpawnObject(){
		Random.seed = System.DateTime.Now.Millisecond;
		int number = Random.Range (0, 2);

		if (number == 0) {
			spawnPos = posA.transform.position;
			incomingA.SetActive (true);
		} else if (number == 1) {
			spawnPos = posB.transform.position;
			incomingB.SetActive (true);
		}
		yield return new WaitForSeconds (spawnTime);
		Instantiate (obj, spawnPos, obj.gameObject.transform.rotation);
		incomingA.SetActive (false);
		incomingB.SetActive (false);
		yield return StartCoroutine(SpawnObject());
	}

	public void Invoking(){
		//Invoke ("SpawnObject", 1);
		StartCoroutine (SpawnObject ());
	}
}
