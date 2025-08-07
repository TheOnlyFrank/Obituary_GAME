using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Health : MonoBehaviour
{
    public int playerHealth;
 
 


    // Handling damage from ranged attacks
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ranged"))
        {
            playerHealth = playerHealth - 1;
            Debug.Log(playerHealth);
            Debug.Log("Ouch!");
        }
    }



    // Keep player's on-screen health updated
    public void Update()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("You died");
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
    }
}
