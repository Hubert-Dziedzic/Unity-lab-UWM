using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_3 : MonoBehaviour
{
    public float speed = 5f;
    private Vector3[] points;
    private int currentPointIndex = 0;

    void Start()
    {
        points = new Vector3[4];
        points[0] = transform.position;
        points[1] = transform.position + new Vector3(10f, 0f, 0f); 
        points[3] = points[2] + new Vector3(-10f, 0f, 0f); 
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex], speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[currentPointIndex]) < 0.01f)
        {
            transform.Rotate(0f, 90f, 0f);
            currentPointIndex = (currentPointIndex + 1) % 4;
        }
    }
}
