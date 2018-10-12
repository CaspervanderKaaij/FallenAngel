using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Transform followNPC;
    public Transform followParticleRing;
    ParticleSystem particle;
    PlayerHealth health;
    float distance = 10;
    Cam cam;
    MainManager mainManager;
    public float outOfRangeDamage = 10f;
    //[HideInInspector]
    public List<Transform> followables;
    public Transform followSelect;
    float startY;

    void Start()
    {
        health = transform.GetComponent<PlayerHealth>();
        particle = followParticleRing.GetComponent<ParticleSystem>();
        distance = particle.shape.radius;
        cam = Camera.main.GetComponent<Cam>();
        mainManager = FindObjectOfType<MainManager>();
        StartNPC();
        transform.position = followNPC.position;
        transform.position += new Vector3(0,3,0);
         startY = transform.position.y;
    }

    void StartNPC()
    {
        if (PlayerPrefs.GetString("follow") != null)
        {
            Followable[] npcs = FindObjectsOfType<Followable>();
            for (int i = 0; i < npcs.Length; i++)
            {
                if (npcs[i].characterName == PlayerPrefs.GetString("follow"))
                {
                    followNPC = npcs[i].transform;
                }
            }
        }
    }

    void LateUpdate(){
        transform.position = new Vector3(transform.position.x,startY,transform.position.z);
    }

    void Update()
    {
        cam.followed = followNPC;
        followParticleRing.position = followNPC.position;
        if (Vector3.Distance(transform.position, followNPC.position) > distance)
        {
            transform.position = followNPC.position;
            mainManager.PlaySound(0, 0);
        }

        if (followables.Count > 1)
        {
            for (int i = 0; i < followables.Count; i++)
            {
                if (followSelect != null)
                {
                    if (followSelect != followables[i])
                    {
                        if (Vector3.Distance(transform.position, followables[i].position) < Vector3.Distance(transform.position, followSelect.position))
                        {
                            followSelect = followables[i];
                        }
                    }
                }
                else
                {
                    followSelect = followables[i];
                }
            }
        }
        else if (followables.Count != 0)
        {
            followSelect = followables[0];
        }
        else
        {
            followSelect = null;
        }
    }
}
