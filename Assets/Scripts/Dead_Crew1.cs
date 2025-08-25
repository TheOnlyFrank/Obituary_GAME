using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Crew1 : MonoBehaviour, IInteractable
{
    public Inventory_Manager inventory;

    [SerializeField] GameObject deadBodyTrigger;

    // Start is called before the first frame update
    public void OnPlayerInteract()
    {
        Debug.Log("Interacting");
        inventory.has_Reactor_Key = true;
        Debug.Log("You got the Reactor Key!");
        Destroy(deadBodyTrigger);
    }
}
