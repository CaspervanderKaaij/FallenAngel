using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject toSpawn;
    public Transform player;
    bool hasController = false;
    public float attackRate = 0.2f;
    MainManager mainManager;
    public Transform spawnPos;
    public bool reflecting = false;
    public GameObject reflectParticle;
    public GameObject reflectCol;
    bool canReflect = true;
    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
    }

    void Update()
    {
        if (mainManager.paused == false)
        {
            if (reflecting == false)
            {
                ShootStuff();
            }
            else
            {
                CancelInvoke("SpawnBullet");
                reflectCol.SetActive(true);
                transform.position = player.position;
            }
        }
        else
        {
            CancelInvoke("SpawnBullet");
        }
    }

    void StopReflect(){
        reflecting = false;
    }

    void SetCanReflect(){
        canReflect = true;
    }

    void ShootStuff()
    {

        if(Input.GetButtonDown("Fire3") == true){
            if(canReflect == true){
            Instantiate(reflectParticle,transform.position,Quaternion.identity,transform);
            mainManager.PlaySound(3,0);
            mainManager.PlaySound(4,0.75f);
            FindObjectOfType<Cam>().StartShake(0.3f,0.6f);
            reflecting = true;
            Invoke("StopReflect",0.3f);
            Invoke("SetCanReflect",0.31f);
            FindObjectOfType<PlayerHealth>().curHealth = 25;
            canReflect = false;
            }
        }
        reflectCol.SetActive(false);

        hasController = false;
        CheckController();
        transform.position = player.position;
        SetAngle();
        if (Input.GetButtonDown("Fire1") == true)
        {
            FindObjectOfType<Cam>().StartShake(0.1f,0.2f);
            InvokeRepeating("SpawnBullet", 0, attackRate);
        }
        if (Input.GetButtonUp("Fire1") == true)
        {
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
        mainManager.PlaySound(5, 0);
        Instantiate(toSpawn, spawnPos.position, transform.rotation);
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
