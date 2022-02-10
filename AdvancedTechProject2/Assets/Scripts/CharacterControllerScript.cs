using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController _controller;
    private JumpTrigger jumptrigger;

    Vector3 move;

    public float speed = 7.5f;
    private Vector3 _velocity = new Vector3(0, 0, 0);
    public float gravityMultiplier = 1.8f;

    public float JumpHeight = 1;
    bool isGrounded;
    public float playerRotationSmoothing = 0.5f;

    private float playerHorizontal;
    private float playerVertical;

    void Start()
    {
        _controller = this.GetComponent<CharacterController>();
        if(_controller != null)
        {
            Debug.Log("Controller found");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (this.gameObject.tag == "Walkable")
        {
            Debug.Log("On The Ground");
        }*/
        /*if (this.gameObject.tag == "Jump Trigger")
        {
            Debug.Log("jumping");
            //Jump();
        }*/
    }

    void Gravity()
    {
        if (_controller.isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }
        else
        {
            _velocity.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    void Run()
    {
        _controller.Move(move * speed * Time.deltaTime);
        _controller.Move(_velocity * Time.deltaTime);

        /*if (move != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, move, playerRotationSmoothing);    
        }*/
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 0.5f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if(isGrounded)
        {
            _velocity.y = 0;
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerVertical = -1;
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerVertical = 1;
        }
        else
        {
            playerVertical = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerHorizontal = -1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerHorizontal = 1;
        }
        else
        {
            playerHorizontal = 0;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
       /* if (jumptrigger.isJumping == true)
        {
            Jump();
        }*/

        move = new Vector3(playerHorizontal, 0, playerVertical);
    }

    void FixedUpdate()
    {
        GroundCheck();
        Gravity();
        Run();
    }
}
