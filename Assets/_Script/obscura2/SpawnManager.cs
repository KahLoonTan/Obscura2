using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	// Use this for initialization
	TileManager tm;
	public GameObject[] mapMonster; //types of monster
	System.Collections.Generic.List<Monster> monsterList = new System.Collections.Generic.List<Monster>(); //list of monster spawned
	float test =5;
	void Start () {
		tm = GameObject.Find ("Map").GetComponent<TileManager> ();

			//SpawnMonster ();

	}
	
	// Update is called once per frame
	void Update () {
		//float test = 10;
		if (test<Time.time) {
			SpawnMonster ();
			test = 100000;
		}
	}

	void SpawnMonster(){
		float tmLat = tm.getLat + UnityEngine.Random.Range (-0.0003f, 0.0003f);
		float tmLon = tm.getLon + UnityEngine.Random.Range (-0.0003f, 0.0003f);
		int tempMonster = Random.Range (0, mapMonster.Length);
		//Monster monster = Instantiate (mapMonster [tempMonster], Vector3.zero, Quaternion.identity) as Monster;
		Instantiate (mapMonster [tempMonster], Vector3.zero, Quaternion.identity);
		Monster monster = mapMonster [tempMonster].GetComponent<Monster> ();
		monster.tm = tm;
		monster.Init (tmLat, tmLon);
		monsterList.Add (monster);


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
