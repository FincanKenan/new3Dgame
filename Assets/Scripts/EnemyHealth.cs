using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHelath;

    EnemeyMovement enemymovement;

    

    public float attackForce;

    public GameObject deatheffectPrefeb;

    void Start()
    {
        currentHelath = maxHealth;
        enemymovement = GetComponent<EnemeyMovement>();
    }

    public void TakeDamage(int damage)
    {
        currentHelath -= damage;
        
        
        
        
        

        if(currentHelath <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GameObject deathEffect = Instantiate(deatheffectPrefeb, transform.position, transform.rotation);
        Destroy(gameObject,0.1f);
        Destroy(deathEffect, 0.4f);
    }

    public void DamageTaken(Vector3 direction)
    {
        Rigidbody enemyRigidbody = enemymovement.rb.GetComponent<Rigidbody>();
        if (enemyRigidbody != null)
        {
            enemyRigidbody.AddForce(direction * attackForce, ForceMode.Impulse);
            enemymovement.agent.enabled = false;
            StartCoroutine(EnemyAgentDelay());
        }
    }

    IEnumerator EnemyAgentDelay()
    {
        yield return new WaitForSeconds(0.5f);
        enemymovement.agent.enabled = true;
        enemymovement.agent.SetDestination(enemymovement.charachterObject.position);
    }
    

    void Update()
    {
        
    }
}
