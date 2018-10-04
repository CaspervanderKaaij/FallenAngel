using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

public Transform player;
public Transform followed;
public Transform pivot;
Vector3 posRelativeToPivot;
Camera cam;

	void Start () {
		cam = transform.GetComponent<Camera>();
		posRelativeToPivot = transform.position - pivot.position;
	}
	
	void Update () {
		transform.position = Vector3.Lerp(transform.position,pivot.position + posRelativeToPivot,Time.deltaTime * 10);
		pivot.position = Vector3.Lerp(player.position,followed.position,0.5f);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, Vector3.Distance(player.position,followed.position) + 20,Time.deltaTime * 10);
		cam.fieldOfView = Mathf.Clamp(cam.fieldOfView,30,70);
	}
}
