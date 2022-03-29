using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Finishtext;
    public GameObject Menu;

    void Start()
    {
        Finishtext.SetActive(false);
        Menu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AICharacter"))
        {
            Finishtext.SetActive(true);
            Menu.SetActive(true);
            Destroy(gameObject);
        }
    }
}
