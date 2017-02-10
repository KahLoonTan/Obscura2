using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterCamera : MonoBehaviour {
	public GameObject navigator;
	public string functionName;
	//instruction
	public GameObject instruction;
	public Text instructionText;
	string loadingText;
	// Use this for initialization
	void Start () {
		loadingText = "Start Camera...";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		instructionText.text = loadingText;
		instructionText.alignment = TextAnchor.MiddleCenter;
		instruction.SetActive (true);
		navigator.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
