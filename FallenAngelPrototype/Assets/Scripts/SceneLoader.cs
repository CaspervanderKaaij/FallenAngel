﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

public int nextScene = 1;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			SceneManager.LoadScene(nextScene);
		}	
	}
}
