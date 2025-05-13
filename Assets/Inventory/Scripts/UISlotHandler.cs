using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlotHandler : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public Image icon;
    public TextMeshProUGUI itemCountText;
    public InventoryManager inventoryManager;

    public void onPointerClick(PointereventData eventData)
    {
        throw new System.NotImplementedException();
    }


    // Start is called before the first frame update
    void Start()
    {
        if(item !=null)
        {
            item = item.Clone();
            icon.sprite = item.itemIcon;
            itemCountText.text = item.itemCount.ToString();
        }
        else
        {
            icon.gameObject.SetActive(false);
            itemCountText.text = string.Empty;
        }
    }

  
}
