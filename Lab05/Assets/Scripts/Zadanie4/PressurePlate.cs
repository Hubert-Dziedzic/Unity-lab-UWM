using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchForce = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                Vector3 upwardForce = Vector3.up * launchForce * 3;
                playerRigidbody.AddForce(upwardForce, ForceMode.Impulse);
            }
        }
    }
}
