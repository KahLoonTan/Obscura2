using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {


	// Initiating the type of filters with their attributes


	StatsController sc;
	MyCamera cam2;
	MyCamera cam3;
	UIProgressBar GrayBatBar;
	UIProgressBar GrayFocBar;
	UIProgressBar SepBatBar;
	UIProgressBar SepFocBar;
	UIProgressBar NVBatBar;
	UIProgressBar NVFocBar;

	[HideInInspector]
	UILabel grayBatBtn;
	UILabel grayFocBtn;
	UILabel sepBatBtn;
	UILabel sepFocBtn;
	UILabel nvBatBtn;
	UILabel nvFocBtn;

	[HideInInspector]
	GameObject purchaseTwo;
	GameObject objectTwo;
	GameObject purchaseThree;
	GameObject objectThree;

	//Use this for initialization
	void Start () {
		if(GameObject.Find("PlayerStats") != null)
			sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		else
			Debug.Log("Stats not found");

		//progress barss
		GrayBatBar = GameObject.Find("ProgressBar#1").GetComponent<UIProgressBar>();
		GrayFocBar = GameObject.Find("ProgressBar#2").GetComponent<UIProgressBar>();
		SepBatBar = GameObject.Find("ProgressBar#3").GetComponent<UIProgressBar>();
		SepFocBar = GameObject.Find("ProgressBar#4").GetComponent<UIProgressBar>();
		NVBatBar = GameObject.Find("ProgressBar#5").GetComponent<UIProgressBar>();
		NVFocBar = GameObject.Find("ProgressBar#6").GetComponent<UIProgressBar>();

		grayBatBtn = GameObject.Find("Price#1").GetComponent<UILabel>();
		grayFocBtn = GameObject.Find("Price#2").GetComponent<UILabel>();
		sepBatBtn = GameObject.Find("Price#3").GetComponent<UILabel>();
		sepFocBtn = GameObject.Find("Price#4").GetComponent<UILabel>();
		nvBatBtn = GameObject.Find("Price#5").GetComponent<UILabel>();
		nvFocBtn = GameObject.Find("Price#6").GetComponent<UILabel>();

		purchaseTwo = GameObject.Find("Purchase#2");
		objectTwo = GameObject.Find("Filter#2");
		purchaseThree = GameObject.Find("Purchase#3");
		objectThree = GameObject.Find("Filter#3");

		//getting saved values
		if(PlayerPrefs.GetInt("Owned2") == 1){
			sc.sepiaLens.owned = true;
		}else{
			sc.sepiaLens.owned= false;
		}
		if(PlayerPrefs.GetInt("Owned3") == 1){
			sc.nightVLens.owned = true;
		}else{
			sc.nightVLens.owned = false;
		}
		sc.grayScaleLens.battery = PlayerPrefs.GetInt("Battery1");
		sc.grayScaleLens.focus = PlayerPrefs.GetInt("Focus1");
		sc.sepiaLens.battery = PlayerPrefs.GetInt("Battery2");
		sc.sepiaLens.focus = PlayerPrefs.GetInt("Focus2");
		sc.nightVLens.battery = PlayerPrefs.GetInt("Battery3");
		sc.nightVLens.focus = PlayerPrefs.GetInt("Focus3");

		setUpShop();
	}
	void resetValue(){
		//reseting values
		PlayerPrefs.SetInt("Owned2",0);
		PlayerPrefs.SetInt("Owned3",0);
		PlayerPrefs.SetInt("Battery1", 1);
		PlayerPrefs.SetInt("Focus1", 1);
		PlayerPrefs.SetInt("Battery2", 1);
		PlayerPrefs.SetInt("Focus2", 1);
		PlayerPrefs.SetInt("Battery3", 1);
		PlayerPrefs.SetInt("Focus3", 1);
	}

	void setUpShop(){
		//Checking filters owned
		//checking Sepia
		if(PlayerPrefs.GetInt("Owned2") == 1){
			sc.sepiaLens.owned = true;
		}else{
			sc.sepiaLens.owned= false;
		}
		if(PlayerPrefs.GetInt("Owned3") == 1){
			sc.nightVLens.owned = true;
		}else{
			sc.nightVLens.owned = false;
		}
		if(sc.sepiaLens.owned){
			purchaseTwo.SetActive(false);
			objectTwo.SetActive(true);
		}else{
			purchaseTwo.SetActive(true);
			objectTwo.SetActive(false);
		}
		//checkingNightV
		if(sc.nightVLens.owned){
			purchaseThree.SetActive(false);
			objectThree.SetActive(true);
		}else{
			purchaseThree.SetActive(true);
			objectThree.SetActive(false);
		}

		refreshMenu();
	}

	void buyingSepia(){
		buyingLens(sc.sepiaLens);
	}

	void buyingNightV(){
		buyingLens(sc.nightVLens);
	}

	void buyingLens(StatsController.Item lens){
		if(!lens.owned && (sc.getCoins() >= lens.cost)){
			lens.owned = true;
			sc.setCoins(-lens.cost);
			if(lens.name == "Sepia")
				PlayerPrefs.SetInt("Owned2",1);
			else
				PlayerPrefs.SetInt("Owned3",1);
			setUpShop();
		}
	}

	void grayBuyingBat(){
		buyingBat(sc.grayScaleLens);
	}
	void sepBuyingBat(){
		buyingBat(sc.sepiaLens);
	}
	void NVBuyingBat(){
		buyingBat(sc.nightVLens);
	}
	void buyingBat(StatsController.Item lens){
		switch(lens.battery){
		case 1:
			if(sc.getCoins() >= 20){
				lens.battery++;
				sc.setCoins(-20);
			}
			break;
		case 2:
			if(sc.getCoins() >= 40){
				lens.battery++;
				sc.setCoins(-40);
			}
			break;
		case 3:
			if(sc.getCoins() >= 60){
				lens.battery++;
				sc.setCoins(-60);
			}
			break;
		case 4:
			if(sc.getCoins() >= 100){
				lens.battery++;
				sc.setCoins(-100);
			}
			break;
		case 5:
			if(sc.getCoins() >= 200){
				lens.battery++;
				sc.setCoins(-200);
			}
			break;
		default:
			break;
		}
		refreshMenu();
	}

	void grayBuyingFoc(){
		buyingFoc (sc.grayScaleLens);
	}
	void sepBuyingFoc(){
		buyingFoc (sc.sepiaLens);
	}
	void NVBuyingFoc(){
		buyingFoc (sc.nightVLens);
	}
	void buyingFoc(StatsController.Item lens){
		switch(lens.focus){
		case 1:
			if(sc.getCoins() >= 50){
				lens.focus++;
				sc.setCoins(-50);
			}
			break;
		case 2:
			if(sc.getCoins() >= 100){
				lens.focus++;
				sc.setCoins(-100);
			}
			break;
		case 3:
			if(sc.getCoins() >= 150){
				lens.focus++;
				sc.setCoins(-150);
			}
			break;
		case 4:
			if(sc.getCoins() >= 200){
				lens.focus++;
				sc.setCoins(-200);
			}
			break;
		case 5:
			if(sc.getCoins() >= 300){
				lens.focus++;
				sc.setCoins(-300);
			}
			break;
		default:
			break;
		}
		refreshMenu();
	}
	
	void refreshMenu(){
		PlayerPrefs.SetInt("Battery1", sc.grayScaleLens.battery);
		PlayerPrefs.SetInt("Focus1", sc.grayScaleLens.focus);
		PlayerPrefs.SetInt("Battery2", sc.sepiaLens.battery);
		PlayerPrefs.SetInt("Focus2", sc.sepiaLens.focus);
		PlayerPrefs.SetInt("Battery3", sc.nightVLens.battery);
		PlayerPrefs.SetInt("Focus3", sc.nightVLens.focus);
		//refresh progress bar
		GrayBatBar.value = (float)(sc.grayScaleLens.battery-1)/5;
		GrayFocBar.value = (float)(sc.grayScaleLens.focus-1)/5;
		SepBatBar.value = (float)(sc.sepiaLens.battery-1)/5;
		SepFocBar.value = (float)(sc.sepiaLens.focus-1)/5;
		NVBatBar.value = (float)(sc.nightVLens.battery-1)/5;
		NVFocBar.value = (float)(sc.nightVLens.focus-1)/5;

		//refresh button label
		//grayscale buttons
		switch(sc.grayScaleLens.battery){
		case 1:		grayBatBtn.text = "$" + 20;
			break;
		case 2:		grayBatBtn.text = "$" + 40;
			break;
		case 3:		grayBatBtn.text = "$" + 60;
			break;
		case 4:		grayBatBtn.text = "$" + 100;
			break;
		case 5:		grayBatBtn.text = "$" + 200;
			break;
		default:	grayBatBtn.text = "MAX";
			break;
		}

		switch(sc.grayScaleLens.focus){
		case 1:		grayFocBtn.text = "$" + 50;
			break;
		case 2:		grayFocBtn.text = "$" + 100;
			break;
		case 3:		grayFocBtn.text = "$" + 150;
			break;
		case 4:		grayFocBtn.text = "$" + 200;
			break;
		case 5:		grayFocBtn.text = "$" + 300;
			break;
		default:	grayFocBtn.text = "MAX";
			break;
		}
			//sepia buttons
		switch(sc.sepiaLens.battery){
		case 1:		sepBatBtn.text = "$" + 20;
			break;
		case 2:		sepBatBtn.text = "$" + 40;
			break;
		case 3:		sepBatBtn.text = "$" + 60;
			break;
		case 4:		sepBatBtn.text = "$" + 100;
			break;
		case 5:		sepBatBtn.text = "$" + 200;
			break;
		default:	sepBatBtn.text = "MAX";
			break;
		}
			
		switch(sc.sepiaLens.focus){
		case 1:		sepFocBtn.text = "$" + 50;
			break;
		case 2:		sepFocBtn.text = "$" + 100;
			break;
		case 3:		sepFocBtn.text = "$" + 150;
			break;
		case 4:		sepFocBtn.text = "$" + 200;
			break;
		case 5:		sepFocBtn.text = "$" + 300;
			break;
		default:	sepFocBtn.text = "MAX";
			break;
		}

		//grayscale buttons
		switch(sc.nightVLens.battery){
		case 1:		nvBatBtn.text = "$" + 20;
			break;
		case 2:		nvBatBtn.text = "$" + 40;
			break;
		case 3:		nvBatBtn.text = "$" + 60;
			break;
		case 4:		nvBatBtn.text = "$" + 100;
			break;
		case 5:		nvBatBtn.text = "$" + 200;
			break;
		default:	nvBatBtn.text = "MAX";
			break;
		}
		
		switch(sc.nightVLens.focus){
		case 1:		nvFocBtn.text = "$" + 50;
			break;
		case 2:		nvFocBtn.text = "$" + 100;
			break;
		case 3:		nvFocBtn.text = "$" + 150;
			break;
		case 4:		nvFocBtn.text = "$" + 200;
			break;
		case 5:		nvFocBtn.text = "$" + 300;
			break;
		default:	nvFocBtn.text = "MAX";
			break;
		}

	}
	// Update is called once per frame
	void Update () {
	}
	
}
