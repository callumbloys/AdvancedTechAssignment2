using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSwitch : MonoBehaviour
{
    public GameObject TempleCamera;
    public GameObject OutsideCamera;

    // Start is called before the first frame update
    void Start()
    {
        TempleCamera.SetActive(true);
        OutsideCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AICharacter"))
        {
            OutsideCamera.SetActive(true);
            TempleCamera.SetActive(false);
        }
    }
}
