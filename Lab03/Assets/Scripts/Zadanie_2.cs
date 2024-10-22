using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_2 : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;

        if (movingForward)
        {
            transform.Translate(Vector3.right * moveDistance);

            if (transform.position.x >= startPosition.x + 10f)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveDistance);

            if (transform.position.x <= startPosition.x)
            {
                movingForward = true;
            }
        }
    }
}
