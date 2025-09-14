using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class InvMan : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    public List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots;

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        //set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();

        Add(itemToAdd);
        Remove(itemToRemove);
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
                //slots[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null; 
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                //slots[i].transform.GetChild(0).GetComponent<TMP_Text>().text = " ";
            }
        }
    }

    public void Add(ItemClass item)
    {
        items.Add(item);
        RefreshUI();
    }

    public void Remove(ItemClass item)
    {
        items.Remove(item);
        RefreshUI();
    }
}
