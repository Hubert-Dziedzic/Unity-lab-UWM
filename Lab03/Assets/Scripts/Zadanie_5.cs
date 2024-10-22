using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_5 : MonoBehaviour
{
    public GameObject cubePrefab;  
    public int numberOfCubes = 10; 
    public Transform corner1, corner2, corner3, corner4; 
    public float minimumDistance = 2f; 

    private List<Vector3> usedPositions = new List<Vector3>(); 

    void Start()
    {
        // Generuj Cube'y miêdzy czterema obiektami
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition;
            int attempts = 0;
            do
            {
                float randomX = Random.Range(Mathf.Min(corner1.position.x, corner2.position.x), Mathf.Max(corner1.position.x, corner2.position.x));
                float randomZ = Random.Range(Mathf.Min(corner1.position.z, corner3.position.z), Mathf.Max(corner1.position.z, corner3.position.z));
                randomPosition = new Vector3(randomX, 0.5f, randomZ);

                attempts++;

                if (attempts > 100)
                {
                    Debug.LogWarning("Nie mo¿na znaleŸæ odpowiedniego miejsca dla Cube'a.");
                    break;
                }

            } while (PositionUsed(randomPosition));

            if (attempts <= 100)
            {
                usedPositions.Add(randomPosition);
                Instantiate(cubePrefab, randomPosition, Quaternion.identity);
            }
        }
    }

    bool PositionUsed(Vector3 position)
    {
        foreach (Vector3 usedPosition in usedPositions)
        {
            if (Vector3.Distance(usedPosition, position) < minimumDistance) 
            {
                return true;
            }
        }
        return false;
    }
}
