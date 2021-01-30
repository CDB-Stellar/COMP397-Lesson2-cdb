using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controller;
    
    public float maxSpeed = 10f;
    public float gravity = -30f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundRadius = 0.5f; //how far from ground
    public LayerMask groundMask;
    public bool isGrounded;

    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>(); //one way to get reference
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask); //spherecast, where, how far, which mask

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //wherever you're looking is forward
        controller.Move(move * maxSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded) //needs to come before gravity
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos() //help see in the editor only
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
