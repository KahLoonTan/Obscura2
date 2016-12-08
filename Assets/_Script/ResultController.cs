using UnityEngine;
using System.Collections;

public class ResultController : MonoBehaviour {
	public UILabel resultInfo;
	public UILabel bonusInfo;
	private GameController gc;
	private StatsController sc;
	private int luckHP;
	private int luckCoins;
	// Use this for initialization
	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		sc = GameObject.Find ("PlayerStats").GetComponent<StatsController>();
		resultInfo.text = "";
		bonusInfo.text = "";
		LuckyChance();
	}
	void LuckyChance(){
		//Coins Earned
		bonusInfo.text += sc.coinsEarned + " Coins earned!";
		//Roulette Starts
		luckHP = Random.Range(0,7);
		luckCoins = Random.Range(0,10);
		Debug.Log("HP : " +luckHP);
		Debug.Log("Coins : " +luckCoins);
		if(luckHP == 1){
			int tempHP = PlayerPrefs.GetInt("PlayerHP");
			PlayerPrefs.SetInt("PlayerHP", tempHP+1);
			resultInfo.text += "\nMaxHP increased by 1!";
		}
		if(luckCoins == 1 || luckCoins == 2){
			sc.setCoins(30);
			bonusInfo.text += "\nExtra Coins + 30!";
		}else if(luckCoins == 0){
			sc.setCoins(100);
			bonusInfo.text += "\nExtra Coins + 100!";
		}
			
	}
	// Update is called once per frame
	void Update () {

	}
}
