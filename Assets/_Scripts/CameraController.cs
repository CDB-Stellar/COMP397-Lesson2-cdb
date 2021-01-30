using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //won't see cursor when running game
    }

    // Update is called once per frame
    void Update()
    {
        //mouse look code, can look up down left right
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //Time.deltaTime gives the difference between frames - scaling it according to game time

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //make sure the rotation doesn't go more than 90 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
