using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    private Vector3 moveDrýcetýon;

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
        //  float jumpVertýcal = Input.GetAxisRaw("Jump");
        isGrounded = Physics.CheckSphere(feetPos.position, 0.3f, whatisGround);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            rb.velocity = Vector3.up * jumpForce;
        }

        // --------------- JUMP ------------------


        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float vertýcalInput = Input.GetAxisRaw("Vertical");
        moveDrýcetýon = new Vector3(horizontalInput, 0f, vertýcalInput).normalized;


        transform.position += moveDrýcetýon * movementSpeed * Time.deltaTime;

        //float targetAngle = Mathf.Atan2(moveDrýcetýon.x, moveDrýcetýon.z) * Mathf.Rad2Deg;
        //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothRef, smoothTime);

        //if (moveDrýcetýon != Vector3.zero)
        //{


        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //}
    }
}
