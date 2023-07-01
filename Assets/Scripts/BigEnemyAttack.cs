using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemyAttack : MonoBehaviour
{
    [SerializeField] public float distance;
    public Transform attackPosition;
    public float attackRange;
    [SerializeField] float attackForce;
    public Transform playerObject;
    public LayerMask playerMask;
    private float attackWait;
    [SerializeField] public float attacktoMoveTime;
    [SerializeField] public float attackTimer;

    NavMeshAgent agent;

    PlayerHealth playerhealth;

    void Start()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distancetoTarget = Vector3.Distance(playerObject.position, transform.position);

        if (distancetoTarget <= distance)
        {
            if(attackWait < 0)
            {
                AttackEnemy();
                attackWait = attackTimer;
            }
            else
            {
                attackWait -= Time.deltaTime;
            }
        }
    }

    public void AttackEnemy()
    {
        agent.enabled = false;

        Collider[] hitPlayer = Physics.OverlapSphere(attackPosition.position, attackRange, playerMask);
        
        if (hitPlayer.Length > 0)
        {
            playerhealth.TakeBigDamage();
        }

        Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
        Vector3 attackDirection = Vector3.up;
        attackDirection.Normalize();
        playerRigidbody.AddForce(attackDirection * attackForce, ForceMode.Impulse);

        StartCoroutine(AttackToMove());
    }

    private IEnumerator AttackToMove()
    {
        yield return new WaitForSeconds(attacktoMoveTime);
        agent.enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(attackPosition.position, attackRange);
    }
}
