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
        Debug.Log("HasarAlýndý");

        healthbar.SetCurrentHealth(currentHealth);

    }

    public void TakeSecondDamage()
    {
        currentHealth -= 15;
        Debug.Log("HasarAlýndý");

        healthbar.SetCurrentHealth(currentHealth);

    }

    public void TakeBigDamage()
    {
        currentHealth -= 25;
        Debug.Log("BüyükHasar");

        healthbar.SetCurrentHealth(currentHealth);
    }

    public void PlayerDie()
    {
        // ölüm animasyonu
        // ölüm efekti
        // ölüm sesi
        Time.timeScale = 0f;
    }
}
