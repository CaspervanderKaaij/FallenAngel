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
    public bool shooting = false;
    public Transform shooter;

    void Start()
    {
        startAngle = transform.eulerAngles;
    }

    void LateUpdate()
    {
        SetAnimation();
        SetAngle();
    }

    void CheckDir()
    {
		//yeah I copied, I have a lot to do ok. Here is where I got it from https://answers.unity.com/questions/523915/compass-directions-n-e-s-w.html
        Vector3 v = shooter.forward;
        v.y = 0;
        v.Normalize();

        if (Vector3.Angle(v, Vector3.forward) <= 45.0)
        {
            //Debug.Log("North");
			dir = Direction.Up;
        }
        else if (Vector3.Angle(v, Vector3.right) <= 45.0)
        {
           // Debug.Log("East");
			dir = Direction.Right;
        }
        else if (Vector3.Angle(v, Vector3.back) <= 45.0)
        {
           // Debug.Log("South");
			dir = Direction.Down;
        }
        else
        {
          //  Debug.Log("West");
			dir = Direction.Left;
        }
    }

    void SetAnimation()
    {

        CheckDir();

        string animName = System.Enum.GetName(typeof(Direction), dir);
        if (shooting == false)
        {
            animName += "Idle";
        }
        else
        {
            animName += "Shoot";
        }
       // Debug.Log(animName);
    }
}
