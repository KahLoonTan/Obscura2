using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {

	// Use this for initialization
	TileManager tm;
	public GameObject[] mapMonster; //types of monster
	System.Collections.Generic.List<Monster> monsterList = new System.Collections.Generic.List<Monster>(); //list of monster spawned
	public float waitSpawnTime, minIntervalTime, maxIntervalTime;
	public Vector3 playerPos;
	public bool toMirror = false;



	void Start () {
		tm = GameObject.Find ("Map").GetComponent<TileManager> ();
		transform.position = new Vector3 (Random.Range (-10, 10), 0.5f, Random.Range (-10, 10));
		waitSpawnTime = 10f;
		minIntervalTime = 5f;
		maxIntervalTime = 15f;
			//SpawnMonster ();

	}
	
	// Update is called once per frame
	void Update () {
		if (waitSpawnTime < Time.time) {
			waitSpawnTime = Time.time + UnityEngine.Random.Range (minIntervalTime, maxIntervalTime);
			SpawnMonster ();
		}
		/*if (Input.GetKeyDown (KeyCode.Space)) {
			UpdateMonsterPosition ();
		}*/


	}

	/*
	void SpawnMonster(){
		float tmLat = tm.getLat + UnityEngine.Random.Range (-0.0001f, 0.0001f);
		float tmLon = tm.getLon + UnityEngine.Random.Range (-0.0001f, 0.0001f);
		int tempMonster = Random.Range (0, mapMonster.Length);
		//Monster monster = Instantiate (mapMonster [tempMonster], Vector3.zero, Quaternion.identity) as Monster;
		GameObject obj = Instantiate (mapMonster [tempMonster], Vector3.zero, mapMonster[tempMonster].transform.rotation) as GameObject;
		Monster monster = obj.GetComponent<Monster> ();
		//Monster monster = mapMonster [tempMonster].GetComponent<Monster> ();
		monster.tm = tm;
		monster.Init (tmLat, tmLon);
		monsterList.Add (monster);


	}
	*/

	void SpawnMonster(){
		int tempMonster = Random.Range (0, mapMonster.Length);
		GameObject obj = Instantiate (mapMonster [tempMonster], transform.position, mapMonster[tempMonster].transform.rotation) as GameObject;
		Monster monster = obj.GetComponent<Monster> ();
		monsterList.Add (monster);
		transform.position = new Vector3 (Random.Range (-10, 10), 0.5f, Random.Range (-10, 10));
	}

	public void UpdateMonsterPosition(){
		if (monsterList.Count == 0)
			return;
		Monster[] monsters = monsterList.ToArray ();

		for (int i = 0; i < monsters.Length; i++) {
			monsters [i].updatePosition ();

		}
	}
}
