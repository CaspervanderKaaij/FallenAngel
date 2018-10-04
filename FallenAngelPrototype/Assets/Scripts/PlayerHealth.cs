using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

public int maxHealth = 100;
public int curHealth = 100;

	void Start () {
		
	}
	
	void Update () {
		if(curHealth > maxHealth){
			curHealth = maxHealth;
		}

		if(curHealth <= 0){
			Die();
		}
	}

	public void Damage(int dmg){
		curHealth -= dmg;
	}

	void Die(){
		SceneManager.LoadScene(0);
	}
}
