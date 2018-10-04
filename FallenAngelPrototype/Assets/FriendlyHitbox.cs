using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHitbox : MonoBehaviour {

public int damage = 1;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Enemy"){
			Hit(other);
			Destroy(gameObject);
		}	
	}

	void Hit(Collider other){
		other.GetComponent<EnemyHealth>().GetHit(damage);
	}
}
