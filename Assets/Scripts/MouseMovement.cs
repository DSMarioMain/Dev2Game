using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 150f;
 
    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;
 
    void Start()
    {
      // Locking the cursor to the middle of the screen and making it invisible
      Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        // Getting mouse inputs
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
       // Control rotation around x axis (Look up and down)
       xRotation -= mouseY;
 
       // Clamp the rotation so I can't Over-rotate (like in real life)
       xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
 
       // Control rotation around y axis (Look up and down)
       yRotation += mouseX;
 
       // Applying both rotations
       transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
 
    }
}
