using UnityEngine;
using System.Collections;

public class EnterCamera : MonoBehaviour {
	public GameObject navigator;
	public string functionName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		navigator.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
