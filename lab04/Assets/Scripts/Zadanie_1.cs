using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public GameObject block;
    public int numberOfObjects = 10;
    public Material[] materials;
    private Bounds platformBounds;

    void Start()
    {
        platformBounds = GetComponent<Renderer>().bounds;
        GenerateRandomPositions();
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
       
    }

    void GenerateRandomPositions()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = UnityEngine.Random.Range(platformBounds.min.x + block.transform.localScale.x / 2, platformBounds.max.x - block.transform.localScale.x / 2);
            float randomZ = UnityEngine.Random.Range(platformBounds.min.z + block.transform.localScale.z / 2, platformBounds.max.z - block.transform.localScale.z / 2);
            positions.Add(new Vector3(randomX, platformBounds.center.y + block.transform.localScale.y / 2, randomZ)); 
        }
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywo³ano coroutine");

        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);

            Renderer renderer = newBlock.GetComponent<Renderer>();
            if (renderer != null && materials.Length > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                renderer.material = randomMaterial;
            }

            yield return new WaitForSeconds(this.delay);
        }

        StopCoroutine(GenerujObiekt());
    }
}
