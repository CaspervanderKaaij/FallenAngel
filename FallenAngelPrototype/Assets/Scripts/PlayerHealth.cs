using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

public float maxHealth = 100;
public float curHealth = 100;
public UIBar uiBar;
public float regenSpeed = 10;

	
	void Update () {
		if(curHealth > maxHealth){
			curHealth = maxHealth;
		} else {
			curHealth = Mathf.MoveTowards(curHealth,maxHealth,Time.deltaTime * regenSpeed);
		}

		if(curHealth <= 0){
			Die();
		}

		if(uiBar != null){
			uiBar.percent = (curHealth / maxHealth) * 100;
		}
	}

	public void Damage(int dmg){
		curHealth -= dmg;
		FindObjectOfType<Cam>().StartShake(0.2f,0.5f);
	}

	void Die(){
		SceneManager.LoadScene(1);
	}
}
