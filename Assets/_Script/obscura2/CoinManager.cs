using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

	// Use this for initialization
	public float waitSpawnTime, minIntervalTime, maxIntervalTime;
	public Vector3 playerPos;
	public bool toMirror = false;
	public GameObject coin;
	public System.Collections.Generic.List<Coin> coinList = new System.Collections.Generic.List<Coin>(); //list of coin spawned
	public System.Collections.Generic.List<GameObject> objList = new System.Collections.Generic.List<GameObject>(); //list of coin spawned

	void Start () {
		transform.position = new Vector3 (Random.Range (-10, 10), 0.5f, Random.Range (-10, 10));
		waitSpawnTime = 10f;
		minIntervalTime = 5f;
		maxIntervalTime = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		if (waitSpawnTime < Time.time) {
			waitSpawnTime = Time.time + UnityEngine.Random.Range (minIntervalTime, maxIntervalTime);
			SpawnCoin ();
		}
		checkTouched ();
	}

	void SpawnCoin(){
		GameObject cloneCoin = Instantiate (coin, transform.position, coin.transform.rotation) as GameObject;
		Coin coinCollect = cloneCoin.GetComponent<Coin> ();
		objList.Add (cloneCoin);
		coinList.Add (coinCollect);
		transform.position = new Vector3 (Random.Range (-10, 10), 0.5f, Random.Range (-10, 10));
	}

	void checkTouched()
	{
		if (coinList.Count == 0) {
			return;
		}

		Coin[] coinArr = coinList.ToArray ();
		//Debug.Log (coinArr.Length);
		for (int i = 0; i < coinArr.Length; i++) {


			if (toMirror == true) {
				coinArr [i].updatePosition ();
			}

			if (Input.touchCount == 1) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

				if (Physics.Raycast (ray, out hit, 100f)) {
					if (hit.transform.tag == "Coin") {
						coinArr[i].setCoin();
						objList[i].SetActive(false);
						//coinArr[i].gameObject.SetActive(false);

						//sc.setCoins (10);
						//isTouched = true;

						//cube.SetActive (true);

					}
				}


				//Debug.Log (coinArr [i].isTouched);

			}

		}
	}
}
