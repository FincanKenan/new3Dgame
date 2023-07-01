using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemeyMovement : MonoBehaviour

{
    public NavMeshAgent agent;
    public Transform charachterObject;
    public Rigidbody rb;
    

    private Vector3 lastPosition;   // Düþman obje yönü ...

     public float movementSpeed;
     public float rotationSpeed;

    PlayerAttack playerattack;
    EnemyHealth enemyHealth;

    

    private void Start()
    {
        agent.speed = movementSpeed;
        playerattack = GetComponent<PlayerAttack>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        lastPosition = transform.position;  // Düþman obje yönü ...
    }
    private void Update()
    {
        if (!agent.enabled)
        {
            return;
        }

        agent.destination = charachterObject.position;


        // ----------  Düþman objelerin gittiði yöne doðru bakmalarýný saðlayan kod. ------------------

        Vector3 currentPosition = transform.position;
        Vector3 moveDirection = currentPosition - lastPosition;

        //if (moveDirection.magnitude > characterRadius)
        //{
        //    agent.destination = charachterObject.position;
        //}


        if (moveDirection.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        lastPosition = currentPosition;

        // ----------  Düþman objelerin gittiði yöne doðru bakmalarýný saðlayan kod. ------------------


     }

    
}
