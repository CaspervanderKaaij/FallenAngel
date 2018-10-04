﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject toSpawn;
    public Transform player;
    bool hasController = false;

    void Update()
    {
        hasController = false;
        CheckController();
        transform.position = player.position;
        if (Input.GetButtonDown("Fire1") == true)
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        if (hasController == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                transform.LookAt(hit.point);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
        }
        else if (Vector2.SqrMagnitude(new Vector2(Input.GetAxis("CamHor"), Input.GetAxis("CamVert"))) > 0)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("CamHor"), Input.GetAxis("CamVert")) * Mathf.Rad2Deg, 0);
        }



        Instantiate(toSpawn, transform.position, transform.rotation);
    }

    void CheckController()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 19)
            {
                hasController = true;
            }
        }
    }
}
