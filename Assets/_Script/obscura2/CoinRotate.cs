using UnityEngine;
using System.Collections;

public class CoinRotate : MonoBehaviour {

	// Use this for initialization
	public int rotateSpeed = 40;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,rotateSpeed*Time.deltaTime,Space.Self);
	}
}
