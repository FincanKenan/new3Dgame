using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public Transform playerObject;

    [SerializeField] public float detectionDistance;
    private float attackWait;
    private float attackReset = 0.5f;

    [SerializeField]public float attackRange;

    public LayerMask playerMask;
    public GameObject attackPoint;

    public bool isAttacking = false;

    [SerializeField]public float attackForce;

    PlayerHealth playerhealth;

    

    void Start()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
       
    }

    void Update()
    {
        float attackDistance = Vector3.Distance(transform.position, playerObject.position);

        if (attackDistance <= detectionDistance)
        {
            if (attackWait <= 0)
            {
                AttackEnemy();
                attackWait = attackReset;
            }
            else
            {
                attackWait -= Time.deltaTime;
            }
            
        }
           
    }

    public void AttackEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.transform.position, attackRange, playerMask);
        if (hitColliders.Length > 0)
        {
            playerhealth.TakeDamage();
           // Debug.Log("attack");
            
        
        }

        Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
        Vector3 attackDirection = playerObject.transform.position - transform.position;
        attackDirection.Normalize();
        playerRigidbody.AddForce(attackDirection * attackForce, ForceMode.Impulse);

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPoint.transform.position, attackRange);
    }




}
