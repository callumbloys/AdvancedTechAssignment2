using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    private CharacterControllerScript charactercontrollerscript;
    //public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        //isJumping = false;
    }

// Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {               
        Debug.Log("jumping");
        //isJumping = true;
        charactercontrollerscript.Jump();
    }
}
