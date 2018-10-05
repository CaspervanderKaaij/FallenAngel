using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprite : MonoBehaviour {
[HideInInspector]
public Vector3 startAngle;
	void Start () {
		startAngle = transform.eulerAngles;
	}
	
	void LateUpdate () {
		SetAngle();
	}

	public void SetAngle(){
		transform.eulerAngles = startAngle;
	}
}
