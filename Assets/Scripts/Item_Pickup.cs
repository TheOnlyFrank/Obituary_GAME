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
    //private Inventory_Manager inventory;


    public void OnPlayerInteract()
    {
        Debug.Log("Interacting");
        
        inventoryManagers.GetComponent<InvMan>().Add(specificScriptableObject, itemQuantity);
        
        if  (specificScriptableObject.itemName == "Blank Keycard")
        {
            GameObject.Find("Player").GetComponent<Inventory_Manager>().has_Blank_Key = true;
        }
        else
        {
            if (specificScriptableObject.itemName == "Pilot Keycard")
            {
                GameObject.Find("Player").GetComponent<Inventory_Manager>().has_Pilot_Key = true;
            }
            else
            {
                if (specificScriptableObject.itemName == "Pistol")
                {
                    GameObject.Find("Player").GetComponent<Inventory_Manager>().has_Pistol = true;
                }
                else
                {
                    //if (specificScriptableObject.itemName == "Pistol Ammo")
                    //{
                    //    GameObject.Find("Player").GetComponent<Inventory_Manager>().Pistol_Ammo = specificScriptableObject.itemQuantity;
                    //}
                }
            }
        }
            //    

            Destroy(gameObject);
    }
}
