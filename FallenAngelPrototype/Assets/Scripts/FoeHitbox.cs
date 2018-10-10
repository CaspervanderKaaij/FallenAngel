using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeHitbox : MonoBehaviour
{

    public int damage = 10;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Hit(other);
            Destroy(gameObject);
        }
        else if (other.tag == "Reflect")
        {
            if (transform.GetComponent<AutoTransform>() != null)
            {
                transform.GetComponent<AutoTransform>().pos = (transform.position - other.transform.position) * -5;
				transform.GetComponent<Renderer>().material.color = Color.blue;
				transform.GetComponentInChildren<TrailRenderer>().endColor = Color.blue;
            }
        }
    }

    void Hit(Collider other)
    {
        other.GetComponent<PlayerHealth>().Damage(damage);
    }
}
