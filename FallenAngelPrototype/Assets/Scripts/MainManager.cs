using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class MainManager : MonoBehaviour
{
    [Header("Pause Stuff")]
    public bool paused = false;
    public RectTransform normalUI;
    public RectTransform bulletPointUI;

    void Start()
    {

    }

    void Update()
    {
        Pause();
    }

    void Pause()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;
            if(paused == true){
                Camera.main.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = true;
            } else {
                Camera.main.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;
            }
        }

        if (paused == true)
        {
            Time.timeScale = 0;
            normalUI.anchoredPosition = Vector3.Lerp (normalUI.anchoredPosition,new Vector3(1920,0,0),Time.unscaledDeltaTime * 50);
            //bulletPointUI.anchoredPosition = Vector3.zero;
            bulletPointUI.anchoredPosition = Vector3.Lerp (bulletPointUI.anchoredPosition,Vector3.zero,Time.unscaledDeltaTime * 50);
        }
        else
        {
            Time.timeScale = 1;
            //normalUI.anchoredPosition = Vector3.zero;
            normalUI.anchoredPosition = Vector3.Lerp (normalUI.anchoredPosition,Vector3.zero,Time.unscaledDeltaTime * 50);
           // bulletPointUI.anchoredPosition = new Vector3(99999,0,0);
           bulletPointUI.anchoredPosition = Vector3.Lerp (bulletPointUI.anchoredPosition,new Vector3(1920,0,0),Time.unscaledDeltaTime * 50);
        }
    }
}
