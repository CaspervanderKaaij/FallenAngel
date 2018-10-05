using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : CharacterSprite
{

    EnemyBehaviour.EnemyType type;
	EnemyBehaviour behaviour;
	public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public Direction dir;

    void Start()
    {
        startAngle = transform.eulerAngles;
		behaviour = transform.parent.GetComponent<EnemyBehaviour>();
        type = behaviour.type;
    }

    void Update()
    {
        SetAngle();
        if (type == EnemyBehaviour.EnemyType.Melee)
        {
            MeleeStuff();
        }
        else
        {
            SniperStuff();
        }
    }

    void MeleeStuff()
    {
		CheckDir();
		if(behaviour.canAttack == true){
			//set anim here
		}
    }

    void SniperStuff()
    {
		CheckDir();
    }

	void CheckDir()
    {
		//yeah I copied, I have a lot to do ok. Here is where I got it from https://answers.unity.com/questions/523915/compass-directions-n-e-s-w.html
        Vector3 v = transform.parent.forward;
        v.y = 0;
        v.Normalize();

        if (Vector3.Angle(v, Vector3.forward) <= 45.0)
        {
			dir = Direction.Up;
        }
        else if (Vector3.Angle(v, Vector3.right) <= 45.0)
        {
			dir = Direction.Right;
        }
        else if (Vector3.Angle(v, Vector3.back) <= 45.0)
        {
			dir = Direction.Down;
        }
        else
        {
			dir = Direction.Left;
        }
    }

}
