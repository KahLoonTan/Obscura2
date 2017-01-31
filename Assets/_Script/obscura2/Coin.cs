using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	StatsController sc;

	// Use this for initialization
	void Start () {
		sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		//coin = PlayerPrefs.GetInt ("Coins");
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			setCoin ();
			destroyCoin ();
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
