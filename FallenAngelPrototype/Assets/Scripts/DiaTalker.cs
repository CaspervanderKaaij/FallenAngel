using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]

public class DiaTalker : MonoBehaviour {

public Sprite[] talkers;
Image img;
public int curTalker;


	void Start () {
		img = GetComponent<Image>();
	}
	
	void Update () {
		img.sprite = talkers[curTalker];
	}
}
