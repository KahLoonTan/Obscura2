using UnityEngine;
using System.Collections;

public class MyGyro : MonoBehaviour {
	Gyroscope m_gyroscope;
	private float tempX;
	private float tempY;
	private float tempZ;
	private float tempW;
	Quaternion initialRotation;
	Quaternion gyroInitialRotation;
	Quaternion convertedRotation;
	// Use this for initialization
	void Start () {
		m_gyroscope = Input.gyro;
		m_gyroscope.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		convertedRotation.x = m_gyroscope.attitude.x;
		convertedRotation.y = m_gyroscope.attitude.y;
		convertedRotation.z = -(m_gyroscope.attitude.z);
		convertedRotation.w = -(m_gyroscope.attitude.w);
		this.transform.rotation = convertedRotation;
	}
}
