using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    private Vector3 moveDr�cet�on;

    public float jumpForce;
    private bool isGrounded;
    public LayerMask whatisGround;
    public Transform feetPos;

    public float smoothTime;
    private float smoothRef;

    

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }




    void Update()
    {
        

        // --------------- JUMP ------------------
        //  float jumpVert�cal = Input.GetAxisRaw("Jump");
        isGrounded = Physics.CheckSphere(feetPos.position, 0.3f, whatisGround);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            rb.velocity = Vector3.up * jumpForce;
        }

        // --------------- JUMP ------------------


        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float vert�calInput = Input.GetAxisRaw("Vertical");
        moveDr�cet�on = new Vector3(horizontalInput, 0f, vert�calInput).normalized;


        transform.position += moveDr�cet�on * movementSpeed * Time.deltaTime;

        //float targetAngle = Mathf.Atan2(moveDr�cet�on.x, moveDr�cet�on.z) * Mathf.Rad2Deg;
        //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothRef, smoothTime);

        //if (moveDr�cet�on != Vector3.zero)
        //{


        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //}
    }
}
