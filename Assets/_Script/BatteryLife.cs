using UnityEngine;
using System.Collections;

public class BatteryLife : MonoBehaviour {
	public float battery = 1;
	private int multiplier;
	public GameController gc;
	StatsController sc;
	public UIProgressBar batteryLife;
	// Use this for initialization
	void Start () {
		sc = GameObject.Find("PlayerStats").GetComponent<StatsController>();
		battery = 1;
	}
	void batteryDrain(){
		switch(sc.activeLens){
		case "GrayScale":
			multiplier = sc.grayScaleLens.battery;
			break;
		case "Sepia":
			multiplier = sc.sepiaLens.battery;
			break;
		case "NightVision":
			multiplier = sc.nightVLens.battery;
			break;
		}
		battery -= Time.deltaTime * (0.02f/ multiplier);
		batteryLife.value = battery;
	}
	// Update is called once per frame
	void Update () {
		batteryDrain();
		if(battery <= 0f){
			gc.triggerGameOver();
		}
	}


}
