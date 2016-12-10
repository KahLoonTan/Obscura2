using UnityEngine;
using System.Collections;

public class Navigation_3d : MonoBehaviour {

	// Use this for initialization
		public GameObject navigator;
		public string functionName;
		void Start () {

		}

		// Update is called once per frame
		void Update () {
				if (Input.touchCount == 1) {
						navigator.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
				}
		}
}
