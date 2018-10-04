using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public enum EnemyType
    {
        Sniper,
        Melee
    }
    public EnemyType type = EnemyType.Sniper;
    Transform player;
    [Header("Sniper")]
    public GameObject sniperProjectile;
    [Range(0, 5)]
    public float fireRate = 1;
    [Header("Melee")]
    public float atkDistance = 4;
    [Range(0, 5)]
    public float attackRate = 0.5f;
    public int damage = 20;
	public float speed = 50;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (type == EnemyType.Sniper)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    void Update()
    {
        switch (type)
        {
            case EnemyType.Sniper:
                SniperBehaviour();
                break;
            case EnemyType.Melee:
                MeleeBehaviour();
                break;
        }
    }

    void SniperBehaviour()
    {
        transform.LookAt(player.position);
    }

    void MeleeAttack()
    {
        player.GetComponent<PlayerHealth>().Damage(damage);
    }

    void MeleeBehaviour()
    {

        if (Vector3.Distance(transform.position, player.position) > atkDistance)
        {
            CancelInvoke("MeleeAttack");
            transform.LookAt(player.position);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if(IsInvoking("MeleeAttack") == false)
        {
            InvokeRepeating("MeleeAttack", attackRate, attackRate);
        }
    }

    void Shoot()
    {
        Instantiate(sniperProjectile, transform.position, transform.rotation);
    }
}
