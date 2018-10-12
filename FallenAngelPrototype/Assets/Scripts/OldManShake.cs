using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManShake : MonoBehaviour
{
    public float rate = 0.4f;
    Cam cam;
    Transform player;
    Animator anim;
    void Start()
    {
        cam = FindObjectOfType<Cam>();
        player = FindObjectOfType<PlayerMove>().transform;
        InvokeRepeating("ShakeIt", rate, rate);
        anim = GetComponent<Animator>();
    }

    void ShakeIt()
    {
        if (Vector3.Distance(transform.position, player.position) < 7.5f)
        {
            if (anim.GetBool("walking") == true)
            {
                cam.StartShake(0.1f, 0.3f);
            }
        }
    }
}
