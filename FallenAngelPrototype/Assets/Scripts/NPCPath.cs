using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPath : MonoBehaviour
{

    public List<Transform> path;
    [HideInInspector]
    public int curPoint = 0;
    public float speed = 3;

    

    void Update()
    {
        if (curPoint < path.Count)
        {
            Walk();
            if (speed > 0)
            {
               // anim.SetBool("walking", true);
            }
            else
            {
               // anim.SetBool("walking", false);
            }
        }
        else
        {
          //  anim.SetBool("walking", false);
        }

        
    }

    void Walk()
    {
        transform.LookAt(path[curPoint].position);
        transform.position += transform.forward * speed * Time.deltaTime;
        //         Debug.Log(path[curPoint].name);

        if (Vector3.Distance(transform.position, path[curPoint].position) < speed * Time.deltaTime)
        {
            curPoint++;
        }
    }

    public void NewPath(List<Transform> newPath, float newSpeed)
    {
        path.Clear();
        path.AddRange(newPath);
        speed = newSpeed;
    }
}
