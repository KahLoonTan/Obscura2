using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	private float tmLat, tmLon;
	private float totalLat = 0.001682f, totalLon = 0.0017f;
	//private float boxLat = 2.9240007516763513f, boxLon = 101.63861989974977f;
	//private float boxLat = 2.92315f,boxLon=101.6384f;
	//private float boxLat = 2.922782f, boxLon=101.6384f;
	private float monsLat = 0, monsLon = 0;


	public Monster monster;
	public TileManager tm;
	mapCoordinates A, B, C, D;

	// Use this for initialization
	void Awake () {
		
		tm = GameObject.Find("Map").GetComponent<TileManager> ();
		monster = GetComponent<Monster> ();
		tmLat = tm.getLat;
		tmLon = tm.getLon;
		monsLat = monster.getmLat;
		monsLon = monster.getmLon;


	}
	
	// Update is called once per frame
	void Update () {
		tmLat = tm.getLat;
		tmLon = tm.getLon;
		monsLat = monster.getmLat;
		monsLon = monster.getmLon;
		A.pointLat = tmLat + totalLat; //A = top left of map
		A.pointLon = tmLon - totalLon;
		B.pointLat = tmLat + totalLat; //B = top right
		B.pointLon = tmLon + totalLon;
		C.pointLat = tmLat - totalLat; //C = bottom left
		C.pointLon = tmLon - totalLon;
		D.pointLat = tmLat - totalLat; //D = bottom right
		D.pointLon = tmLon + totalLon;

		if (monsLat < B.pointLon && monsLon > A.pointLon && monsLat < A.pointLat && monsLon > C.pointLat) {
			//Debug.Log ("hi");
			gameObject.SetActive (true);

		} else {
			gameObject.SetActive (false);
		}
	}



}


struct mapCoordinates{
	public float pointLat, pointLon;

}