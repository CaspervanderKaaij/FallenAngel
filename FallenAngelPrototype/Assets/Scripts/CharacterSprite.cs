using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprite : MonoBehaviour {

Vector3 startAngle;
	void Start () {
		startAngle = transform.eulerAngles;
	}
	
	void LateUpdate () {
		SetAngle();
	}

	void SetAngle(){
		transform.eulerAngles = startAngle;
	}
}
