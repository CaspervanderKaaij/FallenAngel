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
    Animator anim;
    SpriteRenderer sprite;

    void Start()
    {
        startAngle = transform.eulerAngles;
		behaviour = transform.parent.GetComponent<EnemyBehaviour>();
        type = behaviour.type;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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

        if(dir == Direction.Up || dir == Direction.Right){
            anim.Play("MeleeEnemyBackward");
            if(dir == Direction.Right){
                sprite.flipX = true;
            } else {
                sprite.flipX = false;
            }
        } else {
            anim.Play("MeleeEnemyForward");
            if(dir == Direction.Left){
                sprite.flipX = true;
            } else {
                sprite.flipX = false;
            }
        }
    }

    void SniperStuff()
    {
		CheckDir();
    }

	void CheckDir()
    {
		//yeah I copied, I have a lot to do ok. Here is where I got it from https://answers.unity.com/questions/523915/compass-directions-n-e-s-w.html
        transform.parent.eulerAngles += new Vector3(0,45,0);
        Vector3 v = transform.parent.forward;
        transform.parent.eulerAngles -= new Vector3(0,45,0);
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
