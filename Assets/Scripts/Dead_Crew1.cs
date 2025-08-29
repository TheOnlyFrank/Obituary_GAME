using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Crew1 : MonoBehaviour, IInteractable
{
    public Inventory_Manager inventory;

    [SerializeField] GameObject deadBodyTrigger;
    [SerializeField] GameObject EPromptCanvas;
    [SerializeField] private bool reactorKey;
    [SerializeField] private bool coPilotKey;


    // Start is called before the first frame update
    public void OnPlayerInteract()
    {
        Debug.Log("Interacting");
        if (reactorKey)
        {
            inventory.has_Reactor_Key = true;
            Debug.Log("You got the Reactor Key!");
        }
        else
        {
            inventory.has_Co_Pilot_Key = true;
            Debug.Log("You got the Co-Pilot Key!");
        }
            //Destroy(deadBodyTrigger);
            deadBodyTrigger.SetActive(false);
        EPromptCanvas.SetActive(false);
    }
}
