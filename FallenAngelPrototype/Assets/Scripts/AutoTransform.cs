using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTransform : MonoBehaviour {

public Vector3 pos;
public Vector3 angle;
public Vector3 scale;
	
	void Update () {
		transform.position += transform.TransformDirection(pos) * Time.deltaTime;
		transform.Rotate(angle * Time.deltaTime);
		transform.localScale += scale * Time.deltaTime;
	}
}
