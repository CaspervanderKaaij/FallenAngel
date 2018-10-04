using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{

    CharacterController cc;
    Vector3 movV3 = Vector3.zero;
    public float speed = 5;
    Transform mainCam;
    public float accelerationSpeed = 1;
    public float decelerationSpeed = 2;

    void Start()
    {
        cc = transform.GetComponent<CharacterController>();
        mainCam = Camera.main.transform;
    }

    void Update()
    {
        UDLR();
        FinalMove();
    }

    void UDLR()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Vector2.SqrMagnitude(input) > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + mainCam.eulerAngles.y, transform.eulerAngles.z);
        }
        Vector3 v3 = transform.TransformDirection(0, 0, speed * Mathf.RoundToInt(Mathf.Min(Vector2.SqrMagnitude(input), 1)));
        if (Vector2.SqrMagnitude(input) > 0)
        {
            movV3.x = Mathf.Lerp(movV3.x, v3.x, Time.deltaTime * accelerationSpeed);
            movV3.z = Mathf.Lerp(movV3.z, v3.z, Time.deltaTime * accelerationSpeed);
        }
        else
        {
            movV3.x = Mathf.Lerp(movV3.x, v3.x, Time.deltaTime * decelerationSpeed);
            movV3.z = Mathf.Lerp(movV3.z, v3.z, Time.deltaTime * decelerationSpeed);
        }
    }

    void FinalMove()
    {
        cc.Move(movV3 * Time.deltaTime);
    }
}
