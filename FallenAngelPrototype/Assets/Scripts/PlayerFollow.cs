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

    void Start()
    {
        health = transform.GetComponent<PlayerHealth>();
        particle = followParticleRing.GetComponent<ParticleSystem>();
        distance = particle.shape.radius;
        cam = Camera.main.GetComponent<Cam>();
        mainManager = FindObjectOfType<MainManager>();
    }

    void Update()
    {
        cam.followed = followNPC;
        followParticleRing.position = followNPC.position;
        if (Vector3.Distance(transform.position, followNPC.position) > distance)
        {
            transform.position = followNPC.position;
            mainManager.PlaySound(0,0);
        }
    }
}
