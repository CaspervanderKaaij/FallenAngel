using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

public int curHealth = 2;
public GameObject deathParticle;

	void Start () {
		
	}
	
	void Update () {
		if(curHealth <= 0){
			Die();
		}
	}

	void Die(){
		Instantiate(deathParticle,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	public void GetHit(int dmg){
		curHealth -= dmg;
		FindObjectOfType<Cam>().StartShake(0.2f,0.5f);
	}
}
