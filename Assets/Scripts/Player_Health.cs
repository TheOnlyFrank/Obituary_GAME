using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Health : MonoBehaviour
{

    [SerializeField] private GameObject goodHealthIcon;
    [SerializeField] private GameObject cautionHealthIcon;
    [SerializeField] private GameObject dangerHealthIcon;
    
    public int player_Health;


    // Handling damage from ranged attacks
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            player_Health = player_Health - 1;
            Debug.Log(player_Health);
            Debug.Log("Ouch!");
            HealthUIUpdate();
        }
    }



    // Keep player's on-screen health updated
    public void Update()
    {
        if (player_Health <= 0)
        {
            Debug.Log("You died");
            SceneManager.LoadScene("Menu_Scene", LoadSceneMode.Single);
        }
    }

    public void HealthUIUpdate()
    {
        if (player_Health >= 7)
        {
            //sets Inventory Health icon to default/"good" health status
            goodHealthIcon.SetActive(true);
            cautionHealthIcon.SetActive(false);
            dangerHealthIcon.SetActive(false);

        }
        else
        {
            if (player_Health >= 3)
            {
                //sets Inventory Health icon to injured state
                goodHealthIcon.SetActive(false);
                cautionHealthIcon.SetActive(true);
                dangerHealthIcon.SetActive(false);
            }
            else
            {
                //sets Inventory Health icon to badly wounded state
                goodHealthIcon.SetActive(false);
                cautionHealthIcon.SetActive(false);
                dangerHealthIcon.SetActive(true);
            }
        }
    }
}
