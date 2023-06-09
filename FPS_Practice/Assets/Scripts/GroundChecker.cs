using System;
using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            PlayerController.isGround = true;
        }
    }
}
