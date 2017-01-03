using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	StatsController sc;
	public bool isTouched = false;
	CoinManager coinManager;
	public bool toMirror = false;
	public Vector3 playerMovement = Vector3.zero;

	// Use this for initialization
	void Start () {
		sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		coinManager = GameObject.Find ("CoinManager").GetComponent<CoinManager> ();
		//coin = PlayerPrefs.GetInt ("Coins");
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void updatePosition(){

		Vector3 mirrorPlayer = coinManager.playerPos;
		toMirror = coinManager.toMirror;
		if (toMirror==true) {
			mirrorPlayer.x = (-playerMovement.x);
			mirrorPlayer.y = playerMovement.y;
			mirrorPlayer.z = (-playerMovement.z);
			Vector3 finalPos = transform.position + mirrorPlayer;
			this.transform.position = Vector3.MoveTowards(transform.position, finalPos, 10*Time.deltaTime);
			toMirror = false;
		}
	}

	public void setCoin(){
		sc.setCoins (10);
	}

	public void destroyCoin(){
		Destroy (gameObject);
	}
	/*public void setCoins(int num){
		PlayerPrefs.SetInt("Coins", coin + num);
		coin = PlayerPrefs.GetInt("Coins");

	}*/
}
