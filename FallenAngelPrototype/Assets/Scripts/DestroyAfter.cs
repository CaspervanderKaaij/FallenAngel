using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

public float time = 5;
public bool fromStart = true;

	void Start () {
		if(fromStart == true){
			DestroyLater();
		}
	}
	
	public void DestroyLater(){
		Destroy(gameObject,time);
	}
}
