using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
[ExecuteInEditMode]

public class Dialogue : MonoBehaviour
{

    public string[] dialogue;
    public float[] newTextTime;
    public float curTime;
    public int curText;
    Text txt;

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
    }

    void SetDia()
    {
        for (int i = 0; i < 1; i++)
        {
            if (curText <= newTextTime.Length - 1)
            {
                if (curTime > newTextTime[curText])
                {
                    i--;
                    curText++;
                }
            }
            else
            {
                curText = newTextTime.Length;
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
        txt.text = dialogue[curText - 1];
    }
}
