using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Health : MonoBehaviour
{
    public int player_Health;
 
 


    // Handling damage from ranged attacks
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ranged") || other.CompareTag("Melee"))
        {
            player_Health = player_Health - 1;
            Debug.Log(player_Health);
            Debug.Log("Ouch!");
        }
    }



    // Keep player's on-screen health updated
    public void Update()
    {
 
    }
}
