using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDestination : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destination 1 reached");

        if (other.tag == "AICharacter")
        {
            Debug.Log("Destination 1 reached");

         
        }
    }
}
