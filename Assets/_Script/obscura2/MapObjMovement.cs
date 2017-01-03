using UnityEngine;
using System.Collections;

public class MapObjMovement : MonoBehaviour {

	public Vector3 playerMovement = Vector3.zero;
	public bool toMirror = false;
	public MonsterManager spawnManager;

	// Use this for initialization
	void Start () {
		spawnManager = GameObject.Find ("MonsterManager").GetComponent<MonsterManager> ();

	}

	// Update is called once per frame
	void Update () {
		Vector3 mirrorPlayer = spawnManager.playerPos;
		toMirror = spawnManager.toMirror;
		if (toMirror==true) {
			mirrorPlayer.x = (-playerMovement.x);
			mirrorPlayer.y = playerMovement.y;
			mirrorPlayer.z = (-playerMovement.z);
			Vector3 finalPos = transform.position + mirrorPlayer;
			this.transform.position = Vector3.MoveTowards(transform.position, mirrorPlayer, 10*Time.deltaTime);
			toMirror = false;
		}

	}
}
