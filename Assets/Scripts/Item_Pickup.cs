using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour, IInteractable
{
    public Inventory_Manager inventory;

    [SerializeField] GameObject ItemPickupTrigger;
    [SerializeField] GameObject EPromptCanvas;
    [SerializeField] GameObject MeshReference;
    [SerializeField] private bool flashlight;
    [SerializeField] private bool blankKey;

        // Start is called before the first frame update
    public void OnPlayerInteract()
    {
        Debug.Log("Interacting");
        if (flashlight)
        {
            inventory.has_Flashlight = true;
            Debug.Log("You got the Flashlight!");
        }
        else
        {
            inventory.has_Blank_Key = true;
            Debug.Log("You got the Blank Key!");
        }
        ItemPickupTrigger.SetActive(false);
        EPromptCanvas.SetActive(false);
        Destroy(MeshReference);
    }
}
