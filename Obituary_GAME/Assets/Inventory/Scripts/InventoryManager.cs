using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;


public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryGrid;
    public bool messyInventory;

    

    public void PlaceInInventory(UISlotHandler activeSlot, Item item)
    {
        activeSlot.item = item;
        activeSlot.icon.sprite = item.itemIcon;
        activeSlot.itemCountText.text = item.itemCount.ToString();
        activeSlot.icon.gameObject.SetActive(true);       
    }

    public void StackInInventory(UISlotHandler activeSlot, Item item)
    {
        if (activeSlot.item.itemID != item.itemID) { return; }

        activeSlot.item.itemCount += item.itemCount;
        activeSlot.itemCountText.text = activeSlot.item.itemCount.ToString();      
    }

    public void ClearItemSlot(UISlotHandler activeSlot)
    {
        activeSlot.item = null;
        activeSlot.icon.sprite = null;
        activeSlot.itemCountText.text = string.Empty;
        activeSlot.icon.gameObject.SetActive(false);       
    }

}