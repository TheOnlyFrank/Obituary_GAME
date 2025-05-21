using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TriggerStay : MonoBehaviour
{
    //public classes
    public GameObject MedBayCanvas;
    [SerializeField] GameObject Wire_Puzzle_Canvas;

    //private classes
    private PlayerInput playerInput;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    
    private void Start()
    {
        MedBayCanvas.SetActive(false);
        Wire_Puzzle_Canvas.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Wire_Box") && (playerInput.actions["Interact"].WasPressedThisFrame()))
        {
            Debug.Log("Interact button pressed");
            Wire_Puzzle_Canvas.SetActive(true);
            //Time.timeScale = 0;
        }
        else
        {
            if ((other.tag == "MedBayRubble") && (playerInput.actions["Interact"].WasPressedThisFrame()))
            {
                Debug.Log("Interact button pressed");
                MedBayCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if ((other.tag == "MedBayRubble"))
            {
                Debug.Log("Player exited trigger");
                MedBayCanvas.SetActive(false);
            }
    }
}
