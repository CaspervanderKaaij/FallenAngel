using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BarMorningEvent : EventBase
{

    void Start()
    {
        StartStuff();
        SetDialogue(diaValues.text, diaValues.times, diaValues.talker);
        StartCoroutine(EventTimer());
    }
    /*
    One happy reminder of my mistakes. Hi mister hacker. Basically I put in text in my prefab and tried to copy component values, with the prefab.. 
    Fun fact, this is the first event I made!
        void GetAllValues()
        {
            diaValues.talker.Clear();
            diaValues.talker.AddRange(dammit.diaValues.talker);
            diaValues.text.Clear();
            diaValues.text.AddRange(dammit.diaValues.text);
            diaValues.times.Clear();
            diaValues.times.AddRange(dammit.diaValues.times);
        }
    */
    void Update()
    {
        UpdateStuff();
    }

    public override IEnumerator EventTimer()
    {

        yield return new WaitForSeconds(54);
        UnlockBulletPoint(6);
        SpawnNewEvent();
    }
}
