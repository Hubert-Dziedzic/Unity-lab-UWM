using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerColision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Rozpoczęto kontakt z przeszkodą!");
        }
    }
}
