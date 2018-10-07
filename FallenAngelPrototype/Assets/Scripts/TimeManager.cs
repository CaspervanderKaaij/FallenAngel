using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public enum TimeOfDay
	{
		Morning = 1,
		Afternoon = 2,
		Evening = 3,
		Night = 4
	}
	public TimeOfDay timeOfDay;

	void Start(){
		DontDestroyOnLoad(gameObject);
	}
}
