using UnityEngine;
using System.Collections;

public class CameraObscura : MonoBehaviour {
	public string deviceName;
	Texture2D snap;
	public static WebCamTexture wct;
	
	// Use this for initialization
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		deviceName = devices [0].name;
		wct = new WebCamTexture (600,800,20);
		GetComponent<Renderer>().material.mainTexture = wct;
		//baseRotation = transform.rotation;
		wct.Play ();
	}
	public void startCam(){
		wct.Play ();
	}
	public void stopCam(){
		wct.Stop();
	}
	void snapShot(){
		Texture2D snap = new Texture2D (wct.width, wct.height);
		snap.SetPixels (wct.GetPixels ());
		snap.Apply ();
		System.IO.File.WriteAllBytes (
			"/storage/emulated/0/DCIM/Snappy/pic.png",
			snap.EncodeToPNG ()
			);
	}
	// Update is called once per frame
	void Update () {
	}
}
