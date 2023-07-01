using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    public float attackWait;
    private float lastAttack;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    public int weaponDamage;

    
   // [SerializeField] public float attackForce;

    public bool isAttacking = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= attackWait + lastAttack)
        {
            Attack();
            lastAttack = Time.time;
           // Debug.Log("Saldýrý");
            isAttacking = true;

            
        }
        else
        {
            isAttacking = false;
        }
        
    }

    public void Attack()
    {
        Collider[] hitEnemys = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemys)
        {
            EnemyHealth enemyhealth = enemy.GetComponent<EnemyHealth>();

            if (enemyhealth != null)
            {
                enemyhealth.TakeDamage(weaponDamage);

                Vector3 attackDirection = enemy.transform.position - transform.position;
                attackDirection.Normalize();
                enemyhealth.DamageTaken(attackDirection);
            }
            
            
        }
    
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPoint.position,attackRange);
    }
}
