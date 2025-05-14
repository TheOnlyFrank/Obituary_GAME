using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerStay : MonoBehaviour
{
    public GameObject MedBayCanvas;

    private PlayerInput playerInput;

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "MedBayRubble") && (playerInput.actions["Interact"].WasPressedThisFrame()))
        {
            Debug.Log("Interact button pressed");
            MedBayCanvas.SetActive(true);
        }
    }
}
