using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {
	string name;
	int cost;
	bool owned;
	int battery;
	int focus;

	/*public enum CameraType{
		BlackWhite,
		Sepia,
		NightV
	}*/

	public void SetCamera(string n, int c, bool o, int b, int f){
		name = n;
		cost = c;
		owned = o;
		battery = b;
		focus = f;
	}

	public string getName(){
		return name;
	}

	public int getCost(){
		return cost;
	}

	public bool getOwned(){
		return owned;
	}

	public int getBattery(){
		return battery;
	}

	public int getFocus(){
		return focus;
	}

	public void setCost(int c){
		cost = c;
	}

	public void setOwned(bool o){
		owned = o;
	}

	public void setBattery(int b){
		battery = b;
	}

	public void setFocus(int f){
		focus = f;
	}
}
