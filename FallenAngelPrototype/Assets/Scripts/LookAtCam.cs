using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour {

	Transform mainCam;
	void Start () {
		mainCam = FindObjectOfType<Cam>().transform;
	}
	
	void LateUpdate () {
		transform.LookAt(mainCam.position);
		transform.eulerAngles += new Vector3(180,0,180);
	}
}
