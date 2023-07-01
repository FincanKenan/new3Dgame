using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyJumpAttack : MonoBehaviour
{
    public float distance;
    public float jumpForce;
    public float jump;
    public Transform playerObject;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerMask;
    public float attackForce;
    private bool isJumping;
    [SerializeField]public float jumptoMovetime;
    private Rigidbody rb;

    NavMeshAgent agent;

    private float timer;
    private float attackWait = 2f;

    EnemyAttack enemyattack;
    PlayerHealth playerhealth;
    //EnemeyMovement enemymovement;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerhealth = FindObjectOfType<PlayerHealth>();

        //enemymovement = GetComponent<EnemeyMovement>();

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        

        float distanceTotarget = Vector3.Distance(transform.position, playerObject.position);

        if (distanceTotarget <= distance)
        {
            if(timer <= 0)
            {
                
                JumpToCharacter();
                timer = attackWait;

                
            }
            else
            {
                timer -= Time.deltaTime;
              
            }
        }
        //else
        //{
        //    enemymovement = enemymovement.GetComponent<EnemeyMovement>();
        //}
        
    }

    public void JumpToCharacter()
    {
        agent.enabled = false;

        Vector3 direction = (playerObject.position - transform.position).normalized;
        Vector3 jumpforceVector = direction * jumpForce;
        jumpforceVector.y = jump;
        rb.AddForce(jumpforceVector, ForceMode.Impulse);


        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.transform.position, attackRange, playerMask);
        if (hitColliders.Length > 0)
        {
            playerhealth.TakeSecondDamage();
            // Debug.Log("attack")
        }

        Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
        Vector3 attackDirection = playerObject.position - transform.position;
        attackDirection.Normalize();
        playerRigidbody.AddForce(attackDirection * attackForce, ForceMode.Impulse);

        StartCoroutine(JumpToMove());
    }

    IEnumerator JumpToMove()
    {
        yield return new WaitForSeconds(jumptoMovetime);
        agent.enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
