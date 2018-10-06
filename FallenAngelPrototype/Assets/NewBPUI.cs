using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBPUI : MonoBehaviour {

MainManager mainManager;
public bool visible;
RectTransform rect;

	void Start () {
		mainManager = FindObjectOfType<MainManager>();
		rect = transform.GetComponent<RectTransform>();
	}
	
	void Update () {
		if(mainManager.paused == true){
			visible = false;
		}
		if(visible == true){
			rect.anchoredPosition = Vector3.zero;
		} else
		{
			rect.anchoredPosition = new Vector3(0,1080,0);
		}
	}
}
