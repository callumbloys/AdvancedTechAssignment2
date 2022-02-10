using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    public GameObject Finishtext;

    private void Start()
    {
        Finishtext.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AICharacter"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (AIPlayerControls.current_destination == 11)
        {
            Finishtext.SetActive(true);
        }
    }
}
