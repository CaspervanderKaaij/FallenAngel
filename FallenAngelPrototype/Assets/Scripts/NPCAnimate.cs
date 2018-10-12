using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimate : MonoBehaviour
{
    Animator anim;
    bool talking = false;
    NPCPath path;
    Dialogue dia;
    public int diaID = 0;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        path = GetComponent<NPCPath>();
        dia = FindObjectOfType<Dialogue>();
    }

    void Update()
    {
        SetWalkAnim();

        SetTalkAnim();
    }

    void SetWalkAnim()
    {
        if (path != null)
        {
            if (path.curPoint < path.path.Count)
            {
                if (path.speed > 0)
                {
                    anim.SetBool("walking", true);
                }
                else
                {
                    anim.SetBool("walking", false);
                }
            }
            else
            {
                anim.SetBool("walking", false);
            }
        }
    }

    void SetTalkAnim()
    {
        if (dia != null)
        {
            if (dia.talker[dia.curText - 1] == diaID)
            {
                talking = true;
            }
            else
            {
                talking = false;
            }
        }

        if (anim.GetBool("walking") == false)
        {
            if (talking == true)
            {
                anim.speed = 1;
            }
            else
            {
                anim.speed = 0;
                anim.Play(0);
            }
        }
    }

}
