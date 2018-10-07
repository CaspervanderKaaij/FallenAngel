using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSpawner : MonoBehaviour
{

    public GameObject[] eventPrefabs;
    public GameObject[] npcGroupPrefabs;
    int toSpawn = 0;
    void Start()
    {
        toSpawn = GetTimeAndPlace();
        Spawn();
    }

    int GetTimeAndPlace()
    {
        return (SceneManager.GetActiveScene().buildIndex * 4) + (int)FindObjectOfType<TimeManager>().timeOfDay;
    }

    void Spawn()
    {
        if (eventPrefabs[toSpawn] != null)
        {
            Instantiate(eventPrefabs[toSpawn], transform.position, Quaternion.identity);
        }
        if (npcGroupPrefabs[toSpawn] != null)
        {
            Instantiate(npcGroupPrefabs[toSpawn], transform.position, Quaternion.identity);
        }
    }

}
