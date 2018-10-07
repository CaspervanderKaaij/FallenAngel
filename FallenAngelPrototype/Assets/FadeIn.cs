using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    Image img;
    bool started = false;

    void Start()
    {
        img = transform.GetComponent<Image>();
        img.color = Color.black;
		started = false;
    }
    void Update()
    {
        if (started == true)
        {
            if (img.color != Color.clear)
            {
                img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime * 3);
            }
            else
            {
                //transform.GetComponent<FadeIn>().enabled = false;
                enabled = false;
            }
        } else {
			started = true;
		}
    }
}
