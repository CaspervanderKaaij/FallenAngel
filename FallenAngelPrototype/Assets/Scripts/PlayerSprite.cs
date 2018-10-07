using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : CharacterSprite
{

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public Direction dir;
    //public bool shooting = false;
    public Transform shooter;
    Animator anim;

    SpriteRenderer sprite;

    void Start()
    {
        startAngle = transform.eulerAngles;
        anim = transform.GetComponent<Animator>();
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        SetAnimation();
        SetAngle();
    }

    void CheckDir()
    {
        //yeah I copied, I have a lot to do ok. Here is where I got it from https://answers.unity.com/questions/523915/compass-directions-n-e-s-w.html
        shooter.eulerAngles += new Vector3(0, 45, 0);
        Vector3 v = shooter.forward;
        shooter.eulerAngles -= new Vector3(0, 45, 0);
        v.y = 0;
        v.Normalize();

        if (Vector3.Angle(v, Vector3.forward) <= 45.0)
        {
            //Debug.Log("North");
            dir = Direction.Up;
            sprite.flipX = false;
        }
        else if (Vector3.Angle(v, Vector3.right) <= 45.0)
        {
            // Debug.Log("East");
            dir = Direction.Right;
            sprite.flipX = true;
        }
        else if (Vector3.Angle(v, Vector3.back) <= 45.0)
        {
            // Debug.Log("South");
            dir = Direction.Down;
            sprite.flipX = false;
        }
        else
        {
            //  Debug.Log("West");
            dir = Direction.Left;
            sprite.flipX = true;
        }
    }

    void SetAnimation()
    {

        CheckDir();

      //  string animName = System.Enum.GetName(typeof(Direction), dir);
//        if (shooting == false)
     //   {
           // animName += "Idle";
 //       }
      //  else
       // {
         //   animName += "Shoot";
       // }
        // Debug.Log(animName);
        if (dir == Direction.Left || dir == Direction.Down)
        {
            anim.Play("EligorForward");
        }
        else
        {
            anim.Play("EligorBackward");
        }
    }
}
