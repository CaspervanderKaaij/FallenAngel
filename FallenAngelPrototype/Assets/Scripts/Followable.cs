using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followable : MonoBehaviour
{

    Transform player;
    PlayerFollow playerFollow;
    public float range = 10;
    public GameObject ui;
    MainManager mainManager;
    public string characterName = "NoName";

    void Start()
    {
        player = FindObjectOfType<PlayerFollow>().transform;
        playerFollow = FindObjectOfType<PlayerFollow>();
        mainManager = FindObjectOfType<MainManager>();
    }

    void Update()
    {
        ui.SetActive(false);
        if (Vector3.Distance(transform.position, player.position) < range)
        {
            if (playerFollow.followNPC != transform)
            {
                AddToFollowList();
                if (playerFollow.followSelect == transform)
                {
                    ui.SetActive(true);
                    if (Input.GetButtonDown("Fire2") == true)
                    {
                        mainManager.PlaySound(0,0);
                        playerFollow.followNPC = transform;
                        PlayerPrefs.SetString("follow",characterName);
                    }
                }
            }
            else
            {
                RemoveFromFollowList();
            }
        }
        else
        {
            RemoveFromFollowList();
        }
    }

    void AddToFollowList()
    {
        if (playerFollow.followables.Contains(transform) == false)
        {
            playerFollow.followables.Add(transform);
        }
    }

    void RemoveFromFollowList()
    {
        if (playerFollow.followables.Contains(transform) == true)
        {
            playerFollow.followables.Remove(transform);
        }
    }
}
