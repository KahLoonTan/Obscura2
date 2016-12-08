using UnityEngine;
using System.Collections;

public class DiaryController : MonoBehaviour {
	StatsController sc;
	GameObject temp;
	public string chosen;

	public UILabel infoName;
	public UILabel infoMethod;
	public UILabel infoDescrip;

	public GameObject monster1;
	public GameObject monster2;
	public GameObject monster3;
	public GameObject monster4;
	public GameObject monster5;
	public GameObject monster6;
	public GameObject monster7;
	public GameObject monster8;
	public GameObject monster9;
	

	// Use this for initialization
	void Start () {
		sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		sc.getMonstersStats();

		//resetData();
		writeBook();

	}
	void resetData(){
		PlayerPrefs.SetInt("monster1",0);
		PlayerPrefs.SetInt("monster2",0);
		PlayerPrefs.SetInt("monster3",0);
		PlayerPrefs.SetInt("monster4",0);
		PlayerPrefs.SetInt("monster5",0);
		PlayerPrefs.SetInt("monster6",0);
		PlayerPrefs.SetInt("monster7",0);
		PlayerPrefs.SetInt("monster8",0);
		PlayerPrefs.SetInt("monster9",0);
		sc.monsters[0].captured = PlayerPrefs.GetInt("monsters1");
		sc.monsters[1].captured = PlayerPrefs.GetInt("monsters2");
		sc.monsters[2].captured = PlayerPrefs.GetInt("monsters3");
		sc.monsters[3].captured = PlayerPrefs.GetInt("monsters4");
		sc.monsters[4].captured = PlayerPrefs.GetInt("monsters5");
		sc.monsters[5].captured = PlayerPrefs.GetInt("monsters6");
		sc.monsters[6].captured = PlayerPrefs.GetInt("monsters7");
		sc.monsters[7].captured = PlayerPrefs.GetInt("monsters8");
		sc.monsters[8].captured = PlayerPrefs.GetInt("monsters9");
	}
	public void writeBook(){

		for(int i=0 ; i<sc.monsters.Count ; i++){
			temp = Resources.Load<GameObject>("BookObject");
			NGUITools.AddChild(GameObject.Find("Grid"),temp);
			temp.GetComponent<UIDragObject>().target = GameObject.Find("Grid").transform;
			//managing name
			temp = GameObject.Find("BookObject(Clone)").gameObject;
			temp.name = ""+(i);
			if(sc.monsters[i].captured == 1)
				temp.GetComponent<UILabel>().text = sc.monsters[i].name;
			else
				temp.GetComponent<UILabel>().text = "?????";
			//managing tick
			temp = GameObject.Find("Tick").gameObject;
			temp.name = "Tick" + i;
			temp.SetActive(false);
			if(sc.monsters[i].captured == 1){
				temp.SetActive(true);
			}
			//managing chosen
			temp = GameObject.Find("Chosen").gameObject;
			temp.name = "Chosen" + i;
			temp.GetComponent<UISprite>().color = Color.white;
		}
	}

	public void setChosen(string name){
		Debug.Log(int.Parse(name));
		if(sc.monsters[int.Parse(name)].captured == 1){
			chosen = name;
		}

	}
	void clearImage(){
		monster1.SetActive(false);
		monster2.SetActive(false);
		monster3.SetActive(false);
		monster4.SetActive(false);
		monster5.SetActive(false);
		monster6.SetActive(false);
		monster7.SetActive(false);
		monster8.SetActive(false);
		monster9.SetActive(false);

	}
	void checkImage(){
		switch(chosen){
		case "0":
			clearImage();
			monster1.SetActive(true);
			infoName.text = "Crawler";
			infoMethod.text = "GrayScale";
			infoDescrip.text = "The most common Voider around. May seems harmless with it's appearance. But it's not...";
			break;
		case "1":
			clearImage();
			monster2.SetActive(true);
			infoName.text = "Tyarr";
			infoMethod.text = "GrayScale";
			infoDescrip.text = "With a slimey body with no constant shape, it is hard to be found.";
			break;
		case "2":
			clearImage();
			monster3.SetActive(true);
			infoName.text = "Kraydar";
			infoMethod.text = "GrayScale";
			infoDescrip.text = "Kraydar is the alpha of the Crawler family. It is consider as one of the rare species.";
			break;
		case "3":
			clearImage();
			monster4.SetActive(true);
			infoName.text = "Dekrobats";
			infoMethod.text = "NightVision";
			infoDescrip.text = "They always come in a flock, never alone. ";
			break;
		case "4":
			clearImage();
			monster5.SetActive(true);
			infoName.text = "Cazador";
			infoMethod.text = "NightVision";
			infoDescrip.text = "A bee-like Voider that moves very swiftly with it's large wings.";
			break;
		case "5":
			clearImage();
			monster6.SetActive(true);
			infoName.text = "Aerogin";
			infoMethod.text = "NightVision";
			infoDescrip.text = "Dislike to show itself but when it does, it is not a good sign.";
			break;
		case "6":
			clearImage();
			monster7.SetActive(true);
			infoName.text = "Spirat";
			infoMethod.text = "Sepia";
			infoDescrip.text = "A Voider's spirit wandering with no purpose.";
			break;
		case "7":
			clearImage();
			monster8.SetActive(true);
			infoName.text = "Wytch";
			infoMethod.text = "Sepia";
			infoDescrip.text = "Lonely widow that never liked anyone in her sight.";
			break;
		case "8":
			clearImage();
			monster9.SetActive(true);
			infoName.text = "Skeleti";
			infoMethod.text = "Sepia";
			infoDescrip.text = "Formed by countless souls in a single Voider. The power it can hold is limitless.";
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		for(int i=0 ; i<sc.monsters.Count ; i++){
			if(chosen == ""+i){
				Debug.Log("Chosen : " +chosen);
				Debug.Log("find Chosen : " +"Chosen" + (i+1));
				GameObject.Find("Chosen" + i).GetComponent<UISprite>().color = Color.black;
			}else{
				GameObject.Find("Chosen" + i).GetComponent<UISprite>().color = Color.white;
			}
		}
		checkImage();
	
	}
}
