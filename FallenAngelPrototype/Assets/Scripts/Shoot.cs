using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject toSpawn;
    public Transform player;
    bool hasController = false;
    public float attackRate = 0.2f;
    public PlayerSprite sprite;
    MainManager mainManager;

    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
    }

    void Update()
    {
        if (mainManager.paused == false)
        {
            hasController = false;
            CheckController();
            transform.position = player.position;
            SetAngle();
            if (Input.GetButtonDown("Fire1") == true)
            {
                InvokeRepeating("SpawnBullet", 0, attackRate);
                if (sprite != null)
                {
                    sprite.shooting = true;
                }
            }
            if (Input.GetButtonUp("Fire1") == true)
            {
                CancelInvoke("SpawnBullet");
                sprite.shooting = false;
            }
        } else {
            CancelInvoke("SpawnBullet");
        }
    }

    void SetAngle()
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
    }

    void SpawnBullet()
    {
        mainManager.PlaySound(5,0);
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
