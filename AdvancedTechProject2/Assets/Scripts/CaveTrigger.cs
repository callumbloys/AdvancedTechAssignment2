using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTrigger : MonoBehaviour
{
    public GameObject Torch;

    void Start()
    {
        Torch.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("torch on");
        Torch.SetActive(true);

        /*if (this.gameObject.tag == "Player")
        {
            Debug.Log("torch on");
            Torch.SetActive(true);
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("torch off");
        Torch.SetActive(false);
/*
        if (this.gameObject.tag == "Player")
        {
            Torch.SetActive(false);
        }*/
    }
}
