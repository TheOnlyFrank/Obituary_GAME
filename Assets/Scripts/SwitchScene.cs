using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(PlayerInput))]

public class SwitchScene : MonoBehaviour
{

    //   public GameObject player;
    //   private PlayerInput playerInput;
    //   private PlayerControls playerControls;
    //   private CharacterController controller;


    //   private void OnTriggerEnter(Collider other) 
    //   {
    //       controller = player.GetComponent<CharacterController>();
    //       playerControls = new PlayerControls();
    //       playerInput = player.GetComponent<PlayerInput>();
    //
    //       if (other.tag == "Player")
    //       {
    //           Debug.Log("Collider entered"); 
    //           if (playerInput.actions["Interact"].WasPressedThisFrame())
    //           {
    //               Debug.Log("Interact button pressed");
    //               SceneManager.LoadScene("WirePuzzle", LoadSceneMode.Additive);
    //           }
    //       }
    //   }
    public void ChangeScene()
    {
        SceneManager.LoadScene("WirePuzzle", LoadSceneMode.Additive);
    }
}
