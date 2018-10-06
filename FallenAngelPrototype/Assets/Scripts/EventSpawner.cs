using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawner : MonoBehaviour {

public GameObject[] eventPrefabs;
public GameObject[] npcGroupPrefabs;
public int toSpawn = 0;
public int npcToSpawn;
	void Start () {
		Instantiate(eventPrefabs[toSpawn],transform.position,Quaternion.identity);
		Instantiate(npcGroupPrefabs[npcToSpawn],transform.position,Quaternion.identity);
	}
	
}
