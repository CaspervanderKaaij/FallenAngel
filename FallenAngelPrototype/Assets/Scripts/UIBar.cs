using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBar : MonoBehaviour {
[Range(0,100)]
public float percent = 100;
float startScale;

	void Start () {
		startScale = transform.localScale.x;
	}
	
	void Update () {
		transform.localScale = new Vector3(startScale * (percent / 100),transform.localScale.y,transform.localScale.z);
	}
}
