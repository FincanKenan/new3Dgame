using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    [SerializeField]public int currentHealth;

    public HealthBar healthbar;

    EnemyAttack enemyAttack;
    void Start()
    {
        currentHealth = maxHealth;

        enemyAttack = FindObjectOfType<EnemyAttack>();

        healthbar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerDie();
        }


    }
    public void TakeDamage()
    {
        currentHealth -= 5;
        Debug.Log("HasarAl�nd�");

        healthbar.SetCurrentHealth(currentHealth);

    }

    public void TakeSecondDamage()
    {
        currentHealth -= 15;
        Debug.Log("HasarAl�nd�");

        healthbar.SetCurrentHealth(currentHealth);

    }

    public void TakeBigDamage()
    {
        currentHealth -= 25;
        Debug.Log("B�y�kHasar");

        healthbar.SetCurrentHealth(currentHealth);
    }

    public void PlayerDie()
    {
        // �l�m animasyonu
        // �l�m efekti
        // �l�m sesi
        Time.timeScale = 0f;
    }
}
