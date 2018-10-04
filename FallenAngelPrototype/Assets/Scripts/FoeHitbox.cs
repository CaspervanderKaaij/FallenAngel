using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeHitbox : MonoBehaviour {

public int damage = 10;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			Hit(other);
			Destroy(gameObject);
		}	
	}

	void Hit(Collider other){
		other.GetComponent<PlayerHealth>().Damage(damage);
	}
}
