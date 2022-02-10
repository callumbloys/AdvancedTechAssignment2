using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject ObjectiveDoortext;

    private void Start()
    {
        ObjectiveDoortext.SetActive(false);
    }

    void Update()
    {
        if (KeyCollection.keysCollected == 3 && AIPlayerControls.current_destination == 3)
        {
            transform.position += new Vector3(0, 6, 0);
            ObjectiveDoortext.SetActive(true);
        }
        else if (AIPlayerControls.current_destination == 4)
        {
            ObjectiveDoortext.SetActive(false);
        }
    }
}
