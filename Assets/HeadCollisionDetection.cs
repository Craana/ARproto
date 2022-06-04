using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Body"))
        {
            Debug.Log("I hit something!");
        }
    }
}
