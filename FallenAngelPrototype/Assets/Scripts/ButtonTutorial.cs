using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTutorial : MonoBehaviour
{

    public Text txt;
    public string[] dialogue;
    public Image img;
    public Sprite[] sprite;
    public int curTut;
    public bool visible;
    RectTransform rect;
    bool busy = false;
    void Start()
    {
        rect = transform.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, new Vector3(-1920, 0, 0), Time.deltaTime * 10);
        visible = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //curTut++;
        }
        SetText();
        SetVisible();
        WinCondition();
    }

    void WinCondition()
    {
        if (busy == false)
        {
            switch (curTut)
            {
                case 0:
                    if (Vector2.SqrMagnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))) > 0)
                    {
                        StartCoroutine(NextTut(0.3f, 5));
                    }
                    break;
                case 1:
                    StartCoroutine(NextTut(5, 5));
                    break;
                case 2:
                    if (Input.GetButtonDown("Fire1") == true)
                    {
                        StartCoroutine(NextTut(0, 5));
                    }
                    break;
                case 3:
                    if (Input.GetButtonDown("Fire3") == true)
                    {
                        StartCoroutine(NextTut(0, 5));
                    }
                    break;
            }
        }
    }

    IEnumerator NextTut(float startWaitTime, float endWaitTime)
    {
        busy = true;
        yield return new WaitForSeconds(startWaitTime);
        visible = false;
        yield return new WaitForSeconds(endWaitTime);
		if(curTut < dialogue.Length - 1){
        visible = true;
        curTut++;
		}
        busy = false;

    }

    void SetVisible()
    {
        if (visible == true)
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, Vector3.zero, Time.deltaTime * 10);
        }
        else
        {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, new Vector3(-1920, 0, 0), Time.deltaTime * 10);
        }
    }

    void SetText()
    {
        txt.text = dialogue[curTut];
        img.sprite = sprite[curTut];
    }
}
