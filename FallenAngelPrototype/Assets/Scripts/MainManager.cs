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
    [Header("Sound")]
    public GameObject audioSpawn;
    public AudioClip[] sfx;

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
            PlaySound(14,0.3f);
            if(paused == true){
                Camera.main.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = true;
            } else {
                Camera.main.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;
            }
        }

        if (paused == true)
        {
            Time.timeScale = 0;
            normalUI.anchoredPosition = Vector3.Lerp (normalUI.anchoredPosition,new Vector3(0,1080,0),Time.unscaledDeltaTime * 20);
            //bulletPointUI.anchoredPosition = Vector3.zero;
            bulletPointUI.anchoredPosition = Vector3.Lerp (bulletPointUI.anchoredPosition,Vector3.zero,Time.unscaledDeltaTime * 20);
        }
        else
        {
            Time.timeScale = 1;
            //normalUI.anchoredPosition = Vector3.zero;
            normalUI.anchoredPosition = Vector3.Lerp (normalUI.anchoredPosition,Vector3.zero,Time.unscaledDeltaTime * 20);
           // bulletPointUI.anchoredPosition = new Vector3(99999,0,0);
           bulletPointUI.anchoredPosition = Vector3.Lerp (bulletPointUI.anchoredPosition,new Vector3(1920,0,0),Time.unscaledDeltaTime * 20);
        }
    }

    public void PlaySound(int sound,float time){
        AudioSource a = Instantiate(audioSpawn,transform.position,Quaternion.identity).GetComponent<AudioSource>();
        a.clip = sfx[sound];
        a.Play();
        a.time = time;
        Destroy(a.gameObject,a.clip.length);
    }
}
