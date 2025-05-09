using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHealth;




    // Handling damage from ranged attacks
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack") ||  other.CompareTag("PlayerAttack"))
        {
            enemyHealth = enemyHealth - 1;
            Debug.Log(enemyHealth);
            Debug.Log("Ouch!");
        }
    }



    // Keep player's on-screen health updated
    public void Update()
    {
        if (enemyHealth <= 0)
        {
            Debug.Log("It Died");
            Destroy(gameObject);
        }
    }
}