﻿using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >=2){
			Destroy(this.gameObject);
		}
	}
}
