using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_4 : MonoBehaviour
{


    public Transform player;

    public float sensitivity = 200f;

    private float rotationY = 0f;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
     
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationY += mouseXMove;

        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        player.localRotation = Quaternion.Euler(0f, rotationY, 0f);

        float rotationX = -mouseYMove;
        transform.Rotate(new Vector3(rotationX, 0f, 0f), Space.Self);
    }
}
