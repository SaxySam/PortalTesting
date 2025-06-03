using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrianPlayerMoveScript : MonoBehaviour
{

    public CharacterController controller;

    public float walkSpeed = 5f;
    public float runSpeed = 30f;
    public float gravity;
    public float jumpHeight = 3f;

    public Vector3 movementVector = Vector3.zero;
    public Vector3 inputVector = Vector3.zero;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private float speed;

    public Animator adrianAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical") * speed;

        adrianAnimator.SetFloat("WalkSpeed", (Math.Abs(inputVector.z) + Math.Abs(inputVector.x)) / 2);

        /*Vector3 move*/ movementVector = transform.right * inputVector.x + transform.forward * inputVector.z;

        controller.Move(/*move*/ movementVector * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
}
