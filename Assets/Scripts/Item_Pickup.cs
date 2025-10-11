using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour, IInteractable
{
    //InvMan invMan;

    //[SerializeField] GameObject ItemPickupTrigger;
    //[SerializeField] GameObject EPromptCanvas;
    [SerializeField] public GameObject inventoryManagers;

    [SerializeField] private ItemClass specificScriptableObject;
    [SerializeField] public int itemQuantity; 
    //[SerializeField] private bool flashlight;
    //[SerializeField] private bool blankKey;


    public void OnPlayerInteract()
    {
        Debug.Log("Interacting");
        //if **Add check to determine if space in inventory
        //{
        inventoryManagers.GetComponent<InvMan>().Add(specificScriptableObject, itemQuantity);
        //}
        //else
        //{
        //    inventory.has_Blank_Key = true;
        //    Debug.Log("You got the Blank Key!");
        //}
        //ItemPickupTrigger.SetActive(false);
        //EPromptCanvas.SetActive(false);
        Destroy(gameObject);
    }
}
