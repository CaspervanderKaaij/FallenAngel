using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOfDayUI : MonoBehaviour {

TimeManager timeManager;
Text txt;
	void Start () {
		if(FindObjectOfType<TimeManager>() != null){
			timeManager = FindObjectOfType<TimeManager>();
		}
		txt = GetComponent<Text>();
	}
	
	void Update () {
		if(timeManager != null){
			txt.text = "" + timeManager.timeOfDay;
		}
	}
}
