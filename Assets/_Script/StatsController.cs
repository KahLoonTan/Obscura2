using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StatsController : MonoBehaviour {
	public class Item{
		public string name;	//name of Item
		public int cost;	//cost of the Item
		public bool owned;	//is the item in possession
		public int battery; //battery last longer
		public int focus;	//higher focus reveals better monsters
		
		public Item(string n, int c, bool o, int b, int f){
			name = n;		
			cost = c;		
			owned = o;		
			battery = b;	
			focus = f;		
		}
	}

	public class Monster{
		public string name;		//name of monster
		public int captured;	//is the monster captured
		public int loot;		//how much coins rewarded when captured

		public Monster(string n,int c, int l){
			name = n;
			captured = c;
			loot = l;
		}
	}
	Monster monster1 = new Monster("Crawler",0,40);
	Monster monster2 = new Monster("Tyarr",0,80);
	Monster monster3 = new Monster("Kraydar",0,200);
	Monster monster4 = new Monster("Dekrobats",0,50);
	Monster monster5 = new Monster("Cazador",0,70);
	Monster monster6 = new Monster("Aerogin",0,250);
	Monster monster7 = new Monster("Spirat",0,60);
	Monster monster8 = new Monster("Wytch",0,100);
	Monster monster9 = new Monster("Skeleti",0,300);

	public List<Monster> monsters = new List<Monster>();
	public Item grayScaleLens = new Item("GrayScale", 0,true,0,0);
	public Item sepiaLens = new Item("Sepia", 50,false,0,0);
	public Item nightVLens = new Item("NightVision",200,false,0,0);

	public string activeLens;
	public int coinsEarned;
	int coins = 50;


	UILabel cash;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
		loadingMonsters();
		//loading camera's details
		activeLens = grayScaleLens.name;

		//activeLens = PlayerPrefs.GetString("ActiveLens");
		grayScaleLens.battery = PlayerPrefs.GetInt("Battery1");
		grayScaleLens.focus = PlayerPrefs.GetInt("Focus1");
		sepiaLens.battery = PlayerPrefs.GetInt("Battery2");
		sepiaLens.focus = PlayerPrefs.GetInt("Focus2");
		nightVLens.battery = PlayerPrefs.GetInt("Battery3");
		nightVLens.focus = PlayerPrefs.GetInt("Focus3");

		//PlayerPrefs.SetInt("Coins",50);
		coins = PlayerPrefs.GetInt("Coins");

		/*Debug.Log(activeLens);
		Debug.Log(grayScaleLens.battery);
		Debug.Log(grayScaleLens.focus);
		Debug.Log(sepiaLens.battery);
		Debug.Log(sepiaLens.focus);
		Debug.Log(nightVLens.battery);
		Debug.Log(nightVLens.focus);*/


	}
	void loadingMonsters(){
		monsters.Add(monster1);
		monsters.Add(monster2);
		monsters.Add(monster3);
		monsters.Add(monster4);
		monsters.Add(monster5);
		monsters.Add(monster6);
		monsters.Add(monster7);
		monsters.Add(monster8);
		monsters.Add(monster9);
	}

	public void capturedMonster(string capturedName){
		for(int i=0 ; i<monsters.Count ; i++){
			Debug.Log(monsters[i] + " == " + capturedName);
			if(monsters[i].name == capturedName){
				monsters[i].captured = 1;
			}
		}
		setMonstersStats();
	}

	public void lootMonster(string capturedName){
		for(int i=0 ; i<monsters.Count ; i++){
			Debug.Log(monsters[i] + " == " + capturedName);
			if(monsters[i].name == capturedName){
				setCoins(monsters[i].loot);
			}
		}
		setMonstersStats();
	}

	public void setMonstersStats(){
		PlayerPrefs.SetInt("monster1",monsters[0].captured);
		PlayerPrefs.SetInt("monster2",monsters[1].captured);
		PlayerPrefs.SetInt("monster3",monsters[2].captured);
		PlayerPrefs.SetInt("monster4",monsters[3].captured);
		PlayerPrefs.SetInt("monster5",monsters[4].captured);
		PlayerPrefs.SetInt("monster6",monsters[5].captured);
		PlayerPrefs.SetInt("monster7",monsters[6].captured);
		PlayerPrefs.SetInt("monster8",monsters[7].captured);
		PlayerPrefs.SetInt("monster9",monsters[8].captured);
	}

	public void getMonstersStats(){
		monsters[0].captured = PlayerPrefs.GetInt("monster1");
		monsters[1].captured = PlayerPrefs.GetInt("monster2");
		monsters[2].captured = PlayerPrefs.GetInt("monster3");
		monsters[3].captured = PlayerPrefs.GetInt("monster4");
		monsters[4].captured = PlayerPrefs.GetInt("monster5");
		monsters[5].captured = PlayerPrefs.GetInt("monster6");
		monsters[6].captured = PlayerPrefs.GetInt("monster7");
		monsters[7].captured = PlayerPrefs.GetInt("monster8");
		monsters[8].captured = PlayerPrefs.GetInt("monster9");
	}
	

	public bool deleteRandom(){
		int rand = Random.Range(0,9);
		if(monsters[rand].captured == 1){
			monsters[rand].captured = 0;
			setMonstersStats();
			return true;
		}
		return false;
	}
	public void setCoins(int num){
		PlayerPrefs.SetInt("Coins", coins + num);
		coins = PlayerPrefs.GetInt("Coins");
		cash.text = "$" + coins;
		coinsEarned = num;
	}
	public int getCoins(){
		return coins;
	}
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Cash") != null){
			cash = GameObject.Find("Cash").GetComponent<UILabel>();
			cash.text = "$" + coins;
		}
		DontDestroyOnLoad(this);
		activeLens = PlayerPrefs.GetString("ActiveLens");

	}
}
