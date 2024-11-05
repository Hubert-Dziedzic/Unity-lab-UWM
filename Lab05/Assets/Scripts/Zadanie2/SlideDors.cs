using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDors : MonoBehaviour
{
    public Transform leftTrigger;
    public Transform rightTrigger;
    public float openDistance = 5f;
    public float speed = 2f;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isPlayerNear = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + new Vector3(openDistance, 0, 0);
    }

    void Update()
    {
        if (isPlayerNear)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
