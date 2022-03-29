using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    private AIPlayerControls aiplayercontrols;
    public static int keysCollected; 

    private void Awake()
    {
        aiplayercontrols = GetComponent<AIPlayerControls>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AICharacter"))
        {
            keysCollected++; 
            AIPlayerControls.current_destination++;
            Destroy(gameObject);
        }
    }
}
