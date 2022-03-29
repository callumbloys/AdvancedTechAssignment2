using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AICharacter"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }
}
