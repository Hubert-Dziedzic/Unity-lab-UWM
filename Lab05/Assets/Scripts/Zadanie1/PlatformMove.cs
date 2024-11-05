using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform startPoint; 
    public Transform endPoint;  
    public float speed = 2f;     


    private Vector3 targetPosition;
    private bool playerOnPlatform = false;

    void Start()
    {
        targetPosition = endPoint.position;
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = targetPosition == endPoint.position ? startPoint.position : endPoint.position;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            other.transform.parent = null;
        }
    }
}
