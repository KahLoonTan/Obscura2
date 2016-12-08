using UnityEngine;
using System.Collections;

public class CaptureSS : MonoBehaviour {
	public int resWidth = 2550; 
	public int resHeight = 3300;
	
	private bool takeHiResShot = false;
	
	public static string ScreenShotName(int width, int height) {
		return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png", 
		                     Application.persistentDataPath, 
		                     width, height, 
		                     System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}
	
	public void TakeHiResShot() {
		takeHiResShot = true;
	}
	 void takePic(){
		RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
		GetComponent<Camera>().targetTexture = rt;
		Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
		GetComponent<Camera>().Render();
		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
		GetComponent<Camera>().targetTexture = null;
		RenderTexture.active = null; // JC: added to avoid errors
		Destroy(rt);
		byte[] bytes = screenShot.EncodeToPNG();
		string filename = ScreenShotName(resWidth, resHeight);
		System.IO.File.WriteAllBytes(filename, bytes);
		Debug.Log(string.Format("Took screenshot to: {0}", filename));
	}

	void takeASelfie(){
		Debug.Log ("W: " + Screen.width);
		Debug.Log ("H: " + Screen.height);
		Texture2D m_Texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);

		m_Texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
		m_Texture.Apply();
		byte[] bytes = m_Texture.EncodeToPNG ();
		System.IO.File.WriteAllBytes ("GhostPic",bytes);

	}
	void Update() {
		takeHiResShot |= Input.GetKeyDown("k");
		if (takeHiResShot) {
			takePic();
			takeHiResShot = false;
		}
	}
}