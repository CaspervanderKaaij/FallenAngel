using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
[ExecuteInEditMode]

public class Dialogue : MonoBehaviour
{

    public List<string> dialogue;
    public List<float> newTextTime;
    public float curTime;
    public int curText;
    Text txt;
    public GameObject uiBack;
    public DiaTalker diaTalker;
    public List<int> talker;

    void Start()
    {
        txt = transform.GetComponent<Text>();
        if (EditorApplication.isPlaying == true)
        {
            curTime = 0;
        }
    }

    void Update()
    {
        SetDia();
        if (EditorApplication.isPlaying == true)
        {
            curTime += Time.deltaTime;
        }
        if(txt.text == ""){
            uiBack.SetActive(false);
        } else {
            uiBack.SetActive(true);
        }
    }

    void SetDia()
    {
        for (int i = 0; i < 1; i++)
        {
            if (curText <= newTextTime.Count - 1)
            {
                if (curTime > newTextTime[curText])
                {
                    i--;
                    curText++;
                }
            }
            else
            {
                curText = newTextTime.Count;
            }

            if (curTime >= newTextTime[0])
            {
                if (curTime < newTextTime[curText - 1])
                {
                    i--;
                    curText--;
                }
            }
        }
        diaTalker.curTalker = talker[curText - 1];
        txt.text = dialogue[curText - 1];
    }

    public void NewDia(string[] newText,float[] textTime,int[] talkers){
        curText = 1;
        curTime = 0;
        dialogue.Clear();
        dialogue.AddRange(newText);
        newTextTime.Clear();
        newTextTime.AddRange(textTime);
        talker.Clear();
        talker.AddRange(talkers);
    }
}
