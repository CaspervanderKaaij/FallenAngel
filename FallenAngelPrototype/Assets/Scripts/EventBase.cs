using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{

    Dialogue dia;
    List<GameObject> npcs = new List<GameObject>();
    public GameObject[] pathPrefabs;
    public GameObject newEvent;
    public DiaValues diaValues;
    public GameObject[] enemySpawner;
    public enum StartCondition
    {
        Start,
        NoEnemies
    }
    public StartCondition startCondition = StartCondition.Start;
    void Start()
    {
        StartStuff();
        if (startCondition == StartCondition.Start)
        {
            StartCoroutine(EventTimer());
        }
    }

    void Update()
    {
        UpdateStuff();
    }

    public void UpdateStuff()
    {
        if (startCondition == StartCondition.NoEnemies)
        {
            if (FindObjectOfType<EnemySpawner>() == null && FindObjectOfType<EnemyBehaviour>() == null)
            {
                StartCoroutine(EventTimer());
            }
        }
    }

    public virtual IEnumerator EventTimer()
    {
        SetDialogue(diaValues.text, diaValues.times, diaValues.talker);
        yield return new WaitForSeconds(0.01f);
        yield return new WaitForSeconds(3);
        SetNPCPath(0, 0, 10);
        yield return new WaitForSeconds(3);
        SetMusic(2);
        yield return new WaitForSeconds(4);
        SetMusic(0);
        yield return new WaitForSeconds(2);
        SpawnEnemies(0);
        yield return new WaitForSeconds(8);
        UnlockBulletPoint(1);
        yield return new WaitForSeconds(1);
        SpawnNewEvent();
    }

    public void StartStuff()
    {
       // enemySpawner[0] = FindObjectOfType<EnemySpawner>().gameObject;
        dia = FindObjectOfType<Dialogue>();
        if (npcs.Count != 0)
        {
            npcs.Clear();
        }
        npcs.AddRange(GameObject.FindGameObjectsWithTag("NPC"));
    }
    public void SetDialogue(string[] newDia, float[] newTime, int[] talkers)
    {
        dia.NewDia(newDia, newTime, talkers);
    }

    public void SetNPCPath(int npc, int pathNumber, float speed)
    {
        Instantiate(pathPrefabs[pathNumber], transform.position, Quaternion.identity);
        List<Transform> childs = new List<Transform>();
        childs.Clear();
        for (int i = 0; i < pathPrefabs[pathNumber].transform.childCount; i++)
        {
            childs.Add(pathPrefabs[pathNumber].transform.GetChild(i));
        }
        npcs[npc].GetComponent<NPCPath>().NewPath(childs, speed);
    }

    public void SpawnNewEvent()
    {
        Destroy(gameObject);
        if (newEvent != null)
        {
            Instantiate(newEvent, transform.position, Quaternion.identity);
        }
    }

    public void SpawnEnemies(int spawnerNumber)
    {
        Instantiate(enemySpawner[spawnerNumber], transform.position, Quaternion.identity);
    }

    public void SetMusic(int newMusic)
    {
        if (FindObjectOfType<Music>() != null)
        {
            FindObjectOfType<Music>().normalMusic = newMusic;
            FindObjectOfType<Music>().ChangeMusic(newMusic, false);
        }
    }

    public void SetDayTime()
    {
        if (FindObjectOfType<TimeManager>() != null)
        {
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            switch (timeManager.timeOfDay)
            {
                case TimeManager.TimeOfDay.Morning:
                    timeManager.timeOfDay = TimeManager.TimeOfDay.Afternoon;
                    break;
                case TimeManager.TimeOfDay.Afternoon:
                    timeManager.timeOfDay = TimeManager.TimeOfDay.Evening;
                    break;
                case TimeManager.TimeOfDay.Evening:
                    timeManager.timeOfDay = TimeManager.TimeOfDay.Night;
                    break;
                case TimeManager.TimeOfDay.Night:
                    timeManager.timeOfDay = TimeManager.TimeOfDay.Morning;
                    break;
            }
        }
    }

    public void UnlockBulletPoint(int number)
    {
        if (FindObjectOfType<BulletPoints>().unlocked[number] == false)
        {
            FindObjectOfType<BulletPoints>().unlocked[number] = true;
            if (FindObjectOfType<SaveManager>() != null)
            {
                FindObjectOfType<SaveManager>().bulletPoints[number] = true;
            }
            FindObjectOfType<UIBPUnlock>().Unlock(FindObjectOfType<BulletPoints>().factText[number]);
        }
    }
}

[System.Serializable]
public class DiaValues
{
    public string[] text;
    public float[] times;
    public int[] talker;
}
