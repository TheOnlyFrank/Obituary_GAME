using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]

public class Exit_Inventory : MonoBehaviour
{

    private PlayerInput playerInput;


    void CloseInventory()
    {
        if (playerInput.actions["Inventory_Menu"].WasPressedThisFrame())
        {
            //save game call goes here
            SceneManager.LoadScene("Game_Scene", LoadSceneMode.Single);
        }
    }

}