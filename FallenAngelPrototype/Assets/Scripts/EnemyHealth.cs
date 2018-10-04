using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

public int curHealth = 2;

	void Start () {
		
	}
	
	void Update () {
		if(curHealth <= 0){
			Die();
		}
	}

	void Die(){
		Destroy(gameObject);
	}

	public void GetHit(int dmg){
		curHealth -= dmg;
	}
}
