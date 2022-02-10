using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public Material[] material;
    public GameObject button;
    public GameObject door;
    bool doorOpen = false;
    Renderer rend;
    public GameObject Objectivetext;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        Objectivetext.SetActive(false);
        rend.sharedMaterial = material[0];
        button.transform.position += new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (KeyCollection.keysCollected == 7 && doorOpen == false)
        {
            rend.sharedMaterial = material[1];
            Objectivetext.SetActive(true);
        }
        else if (doorOpen == true)
        {
            Objectivetext.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AICharacter"))
        {
            if (!doorOpen)
            {
                rend.sharedMaterial = material[2];
                doorOpen = true;
                door.transform.position += new Vector3(0, 4, 0);
                button.transform.position += new Vector3(0, -0.02f, 0);               
            }
        }
    }
}
