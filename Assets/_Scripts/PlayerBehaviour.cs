using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementForce;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>(); //another way to make a reference to the rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        //Movement axis scale is from -1 to 1. 
        if (Input.GetAxisRaw("Horizontal") > 0) //(raw means no smoothing, it's either on or off (-1 or 1))
        {
            //move right
            //rigidbody.AddForce(new Vector3(1f, 0f, 0f) * movementForce); //could write it this way
            rigidbody.AddForce(Vector3.right * movementForce); //little more convenient 
            Debug.Log("Moving right");
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //move left
            rigidbody.AddForce(Vector3.left * movementForce);
            Debug.Log("Moving left");
        }
    }
}
