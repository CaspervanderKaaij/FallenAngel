using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMorningEvent : EventBase {

	void Start () {
		StartStuff();
		 SetDialogue(diaValues.text, diaValues.times, diaValues.talker);
		StartCoroutine(EventTimer());
	}
	
	void Update () {
		UpdateStuff();
	}

	public override IEnumerator EventTimer(){
		
        yield return new WaitForSeconds(46);
        UnlockBulletPoint(1);
        SpawnNewEvent();
	}
}
