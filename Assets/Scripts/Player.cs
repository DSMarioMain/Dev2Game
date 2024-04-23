using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public bool P1;
    public bool P2;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Resetting default velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Getting inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Creating moving vector
        Vector3 move = transform.right * x + transform.forward * z; //Right = Red Axis, Forward = Blue Axis

        // Move player
        controller.Move(move * speed * Time.deltaTime);

        // Check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // The equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Falling down
        velocity.y += gravity * Time.deltaTime;

        // Making the jump
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            // For later use
        }
        else
        {
            isMoving = false;
            // For later use
        }

        lastPosition = gameObject.transform.position;
    }

    //Make one player move
    /*Vector3 vel = Vector3.zero;
    vel.y = RB.velocity.y;
    if((PlayerOne && Input.GetKey(KeyCode.W))) || (!PlayerOne && Input.GetKey(KeyCode.UpArrow))
    
    if()
    {
        vel += transform.forward * speed
    }*/
}
