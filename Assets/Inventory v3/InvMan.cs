using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class InvMan : MonoBehaviour
{
    [SerializeField] private GameObject itemCursor;
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private GameObject centralScreen;
    [SerializeField] private GameObject buttonSlots;
    [SerializeField] private GameObject equippedScreen;
    [SerializeField] private GameObject playerDropPoint;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;
    [SerializeField] private SlotClass selectedItem;
    

    [SerializeField] private SlotClass[] startingItems;

    private PlayerInput playerInput;

    private SlotClass[] items;

    private GameObject[] slots;

    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;
    private SlotClass activeSlot;

    public SlotClass equippedItem;
    public Player_Controls player_Controls;

    bool isMovingItem;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        centralScreen.transform.GetChild(0).GetComponent<Image>().sprite = null;
        centralScreen.transform.GetChild(1).GetComponent<TMP_Text>().text = null;
    }

    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }
        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }

        //set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();

        //Add(itemToAdd, 1);
        //Remove(itemToRemove);

        buttonSlots.SetActive(false);
        centralScreen.SetActive(false);
        equippedScreen.SetActive(false);
    }

    private void Update()
    {
        Vector2 mouseScreenPosition = playerInput.actions["MousePosition"].ReadValue<Vector2>();

        itemCursor.SetActive(isMovingItem);
        itemCursor.transform.position = mouseScreenPosition;
        if (isMovingItem)
        {
            itemCursor.GetComponent<Image>().sprite = movingSlot.GetItem().itemIcon;
        }
        //if (playerInput.actions["UI_Select"].IsPressed())
        
        //var selectSlot = playerInput.actions["UI_Select"];
        //if (selectSlot.IsPressed())
        
        if (playerInput.actions["UI_Select"].WasPressedThisFrame())
        {
            //find the closest slot (the slot we clicked on)
            //Debug.Log(GetClosestSlot().GetItem());
            if (isMovingItem)
            {
                //end item move
                EndItemMove();
            }
            else
                //UpdateCentralScreens();
                BeginItemMove();

        }
    }
    #region Inventory Utils
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;

                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = items[i].GetQuantity() + "";
                else
                    slots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "";
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null; 
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "";
            }
        }
    }

    public bool Add(ItemClass item, int quantity)
    {
        //check if inventory contains item
        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
            slot.AddQuantity(quantity);
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null) //this is an empty slot
                {
                    items[i].AddItem(item, quantity);
                    break;
                }
            }
 /*           if (items.Count < slots.Length)
            items.Add(new SlotClass(item, quantity));
            else
                return false; */
        }


        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        //items.Remove(item);
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            //if (temp.GetQuantity() > 1)
            //    temp.SubQuantity(1);
            //else
            //{
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }

                items[slotToRemoveIndex].Clear();
            //}
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }
    
    public SlotClass Contains(ItemClass item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i].GetItem() == item)
                return items[i];
        }
        return null;
    }


    #endregion Inventory Utils

    #region Moving Stuff

    private bool BeginItemMove()
    {
        originalSlot = (GetClosestSlot());
        if (originalSlot == null || originalSlot.GetItem() == null)
            return false; //there is no item to move

        movingSlot = new SlotClass(originalSlot);
        selectedItem = new SlotClass(movingSlot);
        UpdateCentralScreens();
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null)
        {
            Add(movingSlot.GetItem(), movingSlot.GetQuantity());
            movingSlot.Clear();
        }
        else
        {
            if (originalSlot.GetItem() != null)
            {
                if (originalSlot.GetItem() == movingSlot.GetItem()) //they're the same item so should stack
                {
                    if (originalSlot.GetItem().isStackable)
                    {
                        originalSlot.AddQuantity(movingSlot.GetQuantity());
                        movingSlot.Clear();
                    }
                    else
                        return false;
                }
                else
                {
                    tempSlot = new SlotClass(originalSlot); // a = b
                    originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity()); // b = c
                    movingSlot.AddItem(tempSlot.GetItem(), tempSlot.GetQuantity()); // a = c
                    UpdateCentralScreens();
                    RefreshUI();
                    return true;

                }
            }
            else //place item as usual
            {
                originalSlot.AddItem(movingSlot.GetItem(), movingSlot.GetQuantity());
                selectedItem = new SlotClass(movingSlot);
                Debug.Log("Selected Item is " + selectedItem.GetItem().itemName);
                movingSlot.Clear();
            }
        }

        isMovingItem = false;
        RefreshUI();
        return true;
    }

    private SlotClass GetClosestSlot()
    {
        Vector2 mouseScreenPosition = playerInput.actions["MousePosition"].ReadValue<Vector2>();

        for (int i = 0; i < slots.Length; i ++)
        {
            if (Vector2.Distance(slots[i].transform.position, mouseScreenPosition) <= 72)
            {
                return items[i];
                break;
            }
        }
        return null;
    }
    #endregion Moving Stuff

    #region Central Screens

    public void UpdateCentralScreens()
    {
        //originalSlot = GetClosestSlot();
        //if (originalSlot == null || originalSlot.GetItem() == null)
        //{
        //    return false; //there is no item to move
        //}
        //else
        //{
            Debug.Log("Central Screens update in progress!");
        //activeSlot = new SlotClass(movingSlot);
            centralScreen.SetActive(true);
            centralScreen.transform.GetChild(0).GetComponent<Image>().sprite = selectedItem.GetItem().itemIcon;
            centralScreen.transform.GetChild(1).GetComponent<TMP_Text>().text = selectedItem.GetItem().description;
            buttonSlots.SetActive(true);
            Debug.Log("Active Slot is " + selectedItem.GetItem().itemName);
            Debug.Log("Original Slot is " + originalSlot.GetItem().itemName);
            
        
    }

    public void DropButton()
    {
        //Drops the currently selected item
        if (selectedItem != null)
        {
            Debug.Log("Drop Button pressed");
            Debug.Log("Item to be dropped is " + selectedItem.GetItem().itemName);

            //GameObject droppedItem = new GameObject();
            //droppedItem.AddComponent<Rigidbody>();
            //droppedItem.AddComponent<BoxCollider>();
            //droppedItem.AddComponent<InstanceItemContainer>().item = selectedItem;

            GameObject itemModel = Instantiate(selectedItem.GetItem().model, playerDropPoint.transform.position, Quaternion.identity);
            itemModel.GetComponent<Item_Pickup>().inventoryManagers=GameObject.Find("Managers");

            Remove(selectedItem.GetItem());
            selectedItem.Clear();
            centralScreen.SetActive(false);
            buttonSlots.SetActive(false);
            //Debug.Log("Dropped is " + selectedItem.GetItem().itemName);
            //UpdateCentralScreens();
            //code to instantiate gameobject based on selected item reference
            //code to clear active slot AND corresponding matching inventory slot
        }
        else
        {
            Debug.Log("No 'Drop Button' activation for you!");
        }
    }

    public void EquipButton()
    {
        //Equips the currently selected item
        if (selectedItem.GetItem().itemName != null)
        {
            Debug.Log("Equip Button pressed");
            equippedItem = selectedItem;
            Debug.Log("Equipped item = " + equippedItem.GetItem().itemName);
            equippedScreen.transform.GetComponent<Image>().sprite = equippedItem.GetItem().itemIcon;
            equippedScreen.SetActive(true);
            //player_Controls.weaponType.Replace("" , equippedItem.GetItem().itemName);

            //Code to unequip/disable other attack types and enable equipped weapon's attack type
        }
        else
        {
            Debug.Log("No active item recognised!");
        }
    }

    public void UseButton()
    {
        //Uses the currently selected item (if consumable item type)
        if (selectedItem != null)
        {
            Debug.Log("Use Button pressed");
            //code to apply effect of item to be used
            //call subquantity function for matching inventory slot item (see searching for matching item script section)
        }
        else
        {
            Debug.Log("No 'Use Button' activation for you!");
        }

    }

    #endregion Central Screens

}
