using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	// Use this for initialization
	public float y0;
	public float amplitude=1;
	public float speed=1;
	public float rotateSpeed=300;
	void Start () {
		y0 = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position.y = y0+amplitude*Mathf.Sin(speed*Time.time);
		transform.position = new Vector3(transform.position.x, y0+amplitude*Mathf.Sin(speed*Time.time) ,transform.position.z);
		transform.Rotate (0,rotateSpeed*Time.deltaTime,0,Space.Self);
	}
}
