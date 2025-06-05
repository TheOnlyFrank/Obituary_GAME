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
    public GameObject Airlock_Canvas;
    public GameObject CivCryoOp;
    public GameObject CrewCryoOp;
    public GameObject Unpowered_Canvas;

    [SerializeField] GameObject Wire_Puzzle_Canvas;
    [SerializeField] GameObject Signalis_Puzzle_Canvas;
    [SerializeField] GameObject Signalis_Puzzle_Canvas_2;


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
        Signalis_Puzzle_Canvas.SetActive(false);
        CrewCanvas.SetActive(false);
        EPrompt.SetActive(false);
        Airlock_Canvas.SetActive(false);
        CivCryoOp.SetActive(false);
        CrewCryoOp.SetActive(false);
        Signalis_Puzzle_Canvas_2.SetActive(false);
        Unpowered_Canvas.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Wire_Box") && (playerInput.actions["Interact"].WasPressedThisFrame()))
        {
            Debug.Log("Interact button pressed");
            EPrompt.SetActive(false);
            Wire_Puzzle_Canvas.SetActive(true);
            
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
                if ((other.tag == "Crew_Trigger") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                {
                    Debug.Log("Interact button pressed");
                    EPrompt.SetActive(false);
                    CrewCanvas.SetActive(true);
                }
                else
                {
                    if ((other.tag == "Crew_Cryo") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                    {
                        Debug.Log("Interact button pressed");
                        EPrompt.SetActive(false);
                        Signalis_Puzzle_Canvas.SetActive(true);
                    }
                    else
                    {
                        if ((other.tag == "Airlock_Trigger") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                        {
                            Debug.Log("Interact button pressed");
                            EPrompt.SetActive(false);
                            Airlock_Canvas.SetActive(true);
                        }
                        else
                        {
                            if ((other.tag == "Civ_Operation") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                            {
                                Debug.Log("Interact button pressed");
                                EPrompt.SetActive(false);
                                CivCryoOp.SetActive(true);
                            }
                            else
                            {
                                if ((other.tag == "Crew_Operation") && (playerInput.actions["Interact"].WasPressedThisFrame()))
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
                                        Signalis_Puzzle_Canvas_2.SetActive(true);
                                    }
                                    else
                                    {
                                        if ((other.tag == "Unpowered_Door") && (playerInput.actions["Interact"].WasPressedThisFrame()))
                                        {
                                            Debug.Log("Interact button pressed");
                                            EPrompt.SetActive(false);
                                            Unpowered_Canvas.SetActive(true);
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
            if ((other.tag == "Crew_Trigger"))
            {
                Debug.Log("Player exited trigger");
                CrewCanvas.SetActive(false);
            }
            else
            {
                if ((other.tag == "Airlock_Trigger"))
                {
                    Debug.Log("Player exited trigger");
                    Airlock_Canvas.SetActive(false);
                }
                else
                {
                    if ((other.tag == "Civ_Operation"))
                    {
                        Debug.Log("Player exited trigger");
                        CivCryoOp.SetActive(false);
                    }
                    else
                    {
                        if((other.tag == "Crew_Operation"))
                        {
                            Debug.Log("Player exited trigger");
                            CrewCryoOp.SetActive(false);
                        }
                        else
                        {
                            if ((other.tag == "Unpowered_Door"))
                            {
                                Debug.Log("Player exited trigger");
                                Unpowered_Canvas.SetActive(false);
                            }
                        }
                    }
                }
            }
        }
    }
}
