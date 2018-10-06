using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBPUnlock : MonoBehaviour
{
    RectTransform rect;
    float time;
    bool unlocking = false;
    void Start()
    {
        rect = transform.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector3(0, 1080, 0);
        time = 0;
    }

    void Update()
    {
        if (unlocking == true)
        {
           ActualUnlock();
        }
    }
    void ActualUnlock()
    {
        time += Time.unscaledDeltaTime;
        if (time < 2)
        {
            rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, new Vector3(0, 432, 0), Time.unscaledDeltaTime * 5000);
            //	yield return new WaitForSeconds(2f);
        }
        else
        if (time < 4)
        {
            rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, new Vector3(0, 1080, 0), Time.unscaledDeltaTime * 5000);
            //	yield return new WaitForSeconds(2f);
        }
        else
        if (rect.anchoredPosition == new Vector2(0, 1080))
        {
            unlocking = false;
			FindObjectOfType<NewBPUI>().visible = true;
        }
    }

    public void Unlock(string text)
    {
        time = 0;
		rect.anchoredPosition = new Vector2(0, 1080);
        unlocking = true;
		transform.parent.GetComponentInChildren<Text>().text = "New Bullet Point!   " + text;
    }
}
