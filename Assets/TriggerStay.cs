using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStay : MonoBehaviour
{
    public GameObject MedBayCanvas;

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "MedBayRubble") && (playerInput.actions["Interact"].WasPressedThisFrame()))
        {
            Debug.Log("Interact button pressed");
            MedBayCanvas.SetActive(true);
        }
    }
}
