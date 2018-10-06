using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public SpawnValues[] values;
    public int curWave = 0;
    Transform player;
    public GameObject spawnParticle;
    public int music = 1;
    MainManager mainManager;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RealSpawn();
        if (FindObjectOfType<Music>() != null)
        {
            FindObjectOfType<Music>().ChangeMusic(music, false);
            //FindObjectOfType<Music>().GetComponent<AudioSource>().time = 0;
        }
        mainManager = FindObjectOfType<MainManager>();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(values[curWave - 1].spawnWaitTime);
        RealSpawn();
        mainManager.PlaySound(15, 0);
    }

    void RealSpawn()
    {
        for (int i = 0; i < values[curWave].toSpawn.Length; i++)
        {
            Vector3 random = new Vector3(Random.Range(-30, 30), 0, Random.Range(30, 90));
            Instantiate(enemyPrefabs[values[curWave].toSpawn[i]], player.position + random, Quaternion.identity);
            Instantiate(spawnParticle, player.position + random, Quaternion.identity);
        }
        if (curWave < values.Length - 1)
        {
            curWave++;
            StartCoroutine(Spawn());
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
[System.Serializable]
public class SpawnValues
{
    public int[] toSpawn;
    public float spawnWaitTime;
}
