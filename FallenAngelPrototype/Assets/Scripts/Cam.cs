using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public Transform player;
    public Transform followed;
    public Transform pivot;
    Vector3 posRelativeToPivot;
    Camera cam;
    public bool shaking = false;
    float shakeStr = 2;
    Vector3 lastPos;
    MainManager mainManager;
    //bool hasChangedMusic = false;

    void Start()
    {
        cam = transform.GetComponent<Camera>();
        posRelativeToPivot = transform.position - pivot.position;
        lastPos = transform.position;
        mainManager = FindObjectOfType<MainManager>();
        transform.position = pivot.position + posRelativeToPivot;
        cam.fieldOfView = Vector3.Distance(player.position, followed.position) + 20;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 70);
    }

    void Update()
    {
        transform.position = lastPos;
        transform.position = Vector3.Lerp(transform.position, pivot.position + posRelativeToPivot, Time.deltaTime * 10);
        pivot.position = Vector3.Lerp(player.position, followed.position, 0.5f);
        if (FindObjectOfType<EnemySpawner>() == null && FindObjectOfType<EnemyBehaviour>() == null)
        {
            //  if(hasChangedMusic == false){
            // FindObjectOfType<Music>().ChangeMusic(0,true);
            //  hasChangedMusic = true;
            //  }
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, Vector3.Distance(player.position, followed.position) + 20, Time.deltaTime * 10);
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 30, 70);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80, Time.deltaTime * 10);
            //  hasChangedMusic = false;
        }

        if (shaking == true)
        {
            if (mainManager.paused == false)
            {
                lastPos = transform.position;
                transform.position += new Vector3(Random.Range(-shakeStr, shakeStr), Random.Range(-shakeStr, shakeStr), Random.Range(-shakeStr, shakeStr));
            }
        }
        else
        {
            lastPos = transform.position;
        }

        //	if(Input.GetButtonDown("Fire1") == true){
        //		StartShake(0.2f,0.5f);
        //	}
    }

    public void StartShake(float shakeTime, float strength)
    {
        CancelInvoke("StopShake");
        Invoke("StopShake", shakeTime);
        shaking = true;
        shakeStr = strength;
    }

    void StopShake()
    {
        shaking = false;
    }
}
