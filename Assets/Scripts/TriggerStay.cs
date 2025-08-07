using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.SceneManagement;

public class TriggerStay : MonoBehaviour
{
    //public classes
    public GameObject EPrompt;
    public GameObject MedBayCanvas;
    public GameObject CrewCanvas;
    public GameObject AirlockCanvas;
    public GameObject CivCryoOp;
    public GameObject CrewCryoOp;
    public GameObject UnpoweredCanvas;
    
    [SerializeField] GameObject WirePuzzleCanvas;
    [SerializeField] GameObject SignalisPuzzleCanvas;
    [SerializeField] GameObject SignalisPuzzleCanvas2;
    [SerializeField] GameObject ComputerKeycardsCanvas;
    [SerializeField] GameObject BridgeCanvas;
    [SerializeField] GameObject EndLevelCanvas;
    [SerializeField] GameObject Player;

    //private classes
    private PlayerInput playerInput;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        MedBayCanvas.SetActive(false);
        WirePuzzleCanvas.SetActive(false);
        SignalisPuzzleCanvas.SetActive(false);
        CrewCanvas.SetActive(false);
        EPrompt.SetActive(false);
        AirlockCanvas.SetActive(false);
        CivCryoOp.SetActive(false);
        CrewCryoOp.SetActive(false);
        SignalisPuzzleCanvas2.SetActive(false);
        UnpoweredCanvas.SetActive(false);
        ComputerKeycardsCanvas.SetActive(false);
        BridgeCanvas.SetActive(false);
        EndLevelCanvas.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "WireBox") && (playerInput.actions["Interact"].WasPressedThisFrame()))
        {
            Debug.Log("Interact button pressed");
            EPrompt.SetActive(false);
            WirePuzzleCanvas.SetActive(true);
            
        }
        else
        {
            if ((other.tag == "MedBayRubble") && (playerInput.actions["Interact"].WasPressedThisFrame()))
            {
                Debug.Log("Interact button pressed");
                EPrompt.SetActive(false);
                MedBayCanvas.SetActive(true);
            }
            else
            {
                if ((other.tag == "CrewTrigger") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                {
                    Debug.Log("Interact button pressed");
                    EPrompt.SetActive(false);
                    CrewCanvas.SetActive(true);
                }
                else
                {
                    if ((other.tag == "CrewCryo") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                    {
                        Debug.Log("Interact button pressed");
                        EPrompt.SetActive(false);
                        SignalisPuzzleCanvas.SetActive(true);
                    }
                    else
                    {
                        if ((other.tag == "AirlockTrigger") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                        {
                            Debug.Log("Interact button pressed");
                            EPrompt.SetActive(false);
                            AirlockCanvas.SetActive(true);
                        }
                        else
                        {
                            if ((other.tag == "CivOperation") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                            {
                                Debug.Log("Interact button pressed");
                                EPrompt.SetActive(false);
                                CivCryoOp.SetActive(true);
                            }
                            else
                            {
                                if ((other.tag == "CrewOperation") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                                {
                                    Debug.Log("Interact button pressed");
                                    EPrompt.SetActive(false);
                                    CrewCryoOp.SetActive(true);
                                }
                                else
                                {
                                    if ((other.tag == "Reactor") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                                    {
                                        Debug.Log("Interact button pressed");
                                        EPrompt.SetActive(false);
                                        SignalisPuzzleCanvas2.SetActive(true);
                                    }
                                    else
                                    {
                                        if ((other.tag == "UnpoweredDoor") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                                        {
                                            Debug.Log("Interact button pressed");
                                            EPrompt.SetActive(false);
                                            UnpoweredCanvas.SetActive(true);
                                        }
                                        else
                                        {
                                            if ((other.tag == "ComputerRoom") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                                            {
                                                Debug.Log("Interact button pressed");
                                                EPrompt.SetActive(false);
                                                ComputerKeycardsCanvas.SetActive(true);
                                            }
                                            else
                                            {
                                                if ((other.tag == "Bridge") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                                                {
                                                    Debug.Log("Interact button pressed");
                                                    EPrompt.SetActive(false);
                                                    BridgeCanvas.SetActive(true);
                                                }
                                                else
                                                {
                                                    if (other.tag == "EndLevel")
                                                    {
                                                        Debug.Log("Entered Level End Area");
                                                        EndLevelCanvas.SetActive(true);
                                                        Player.SetActive(false);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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
        else
        {
            if ((other.tag == "CrewTrigger"))
            {
                Debug.Log("Player exited trigger");
                CrewCanvas.SetActive(false);
            }
            else
            {
                if ((other.tag == "AirlockTrigger"))
                {
                    Debug.Log("Player exited trigger");
                    AirlockCanvas.SetActive(false);
                }
                else
                {
                    if ((other.tag == "CivOperation"))
                    {
                        Debug.Log("Player exited trigger");
                        CivCryoOp.SetActive(false);
                    }
                    else
                    {
                        if((other.tag == "CrewOperation"))
                        {
                            Debug.Log("Player exited trigger");
                            CrewCryoOp.SetActive(false);
                        }
                        else
                        {
                            if ((other.tag == "UnpoweredDoor"))
                            {
                                Debug.Log("Player exited trigger");
                                UnpoweredCanvas.SetActive(false);
                            }
                            else
                            {
                                if ((other.tag == "ComputerRoom"))
                                {
                                    Debug.Log("Player exited trigger");
                                    ComputerKeycardsCanvas.SetActive(false);
                                }
                                else
                                {
                                    if ((other.tag == "Bridge"))
                                    {
                                        Debug.Log("Player exited trigger");
                                        BridgeCanvas.SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
