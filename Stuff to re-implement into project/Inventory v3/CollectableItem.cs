using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour, IInteractable
{
    public SlotClass stack;

    private void Awake() {
        if(stack == null || stack.GetItem() == null) return;

        var model = stack.GetItem().model;
        if(model)
        {
            Instantiate(model, transform.position, Quaternion.identity, transform);
        }
    }

    public void OnPlayerInteract()
    {
        GameManager.Instance.Inventory.Add(stack.GetItem(), stack.GetQuantity());
        Destroy(gameObject);
    }

}
