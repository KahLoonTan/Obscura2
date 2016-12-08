using UnityEngine;
using System.Collections;

public class ChangeEquip : MonoBehaviour {
	public NightVisionEffect nv;
	public Texture2D scan1;
	public Texture2D scan2;
	public Texture2D scan3;

	public Texture2D noise1;
	public Texture2D noise2;
	public Texture2D noise3;

	public GameObject equip1;
	public GameObject equip2;
	public GameObject equip3;
	
	private GameController gc;
	StatsController sc;
	// Use this for initialization
	void Start () {
		sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		gc = GameObject.Find ("GameController").GetComponent<GameController>();
		switch(sc.activeLens){
		case "GrayScale":
			changingEquip1();
			break;
		case "Sepia":
			changingEquip2();
			break;
		case "NightVision":
			changingEquip3();
			break;
		}
		if(sc.sepiaLens.owned == false){
			equip2.SetActive(false);
		}
		if(sc.nightVLens.owned == false){
			equip3.SetActive(false);
		}
	}
	void changingEquip1(){
		//Grayscale
		nv.nightVisionNoise = noise2;
		nv.scanLineTexture = scan2;
		GameObject.Find("Main Camera").GetComponent<SepiaToneEffect>().enabled = false;
		GameObject.Find("Main Camera").GetComponent<GrayscaleEffect>().enabled = true;
		PlayerPrefs.SetString("ActiveLens",sc.grayScaleLens.name);
		GameObject.Find("DropDown").SetActive(false);
		gc.resetSpawn();

	}
	void changingEquip2(){
		//Sepia
		nv.nightVisionNoise = noise1;
		nv.scanLineTexture = scan1;
		GameObject.Find("Main Camera").GetComponent<GrayscaleEffect>().enabled = false;
		GameObject.Find("Main Camera").GetComponent<SepiaToneEffect>().enabled = true;
		PlayerPrefs.SetString("ActiveLens",sc.sepiaLens.name);
		GameObject.Find("DropDown").SetActive(false);
		gc.resetSpawn();
	}
	void changingEquip3(){
		//NightVision
		nv.nightVisionNoise = noise1;
		nv.scanLineTexture = scan3;
		GameObject.Find("Main Camera").GetComponent<SepiaToneEffect>().enabled = false;
		GameObject.Find("Main Camera").GetComponent<GrayscaleEffect>().enabled = false;
		PlayerPrefs.SetString("ActiveLens",sc.nightVLens.name);
		GameObject.Find("DropDown").SetActive(false);
		gc.resetSpawn();
	}
	// Update is called once per frame
	void Update () {
	

	}
}
