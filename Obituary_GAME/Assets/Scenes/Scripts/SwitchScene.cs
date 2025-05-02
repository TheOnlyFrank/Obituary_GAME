using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    void Update() 
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            print("e key was pressed");
        }
    }


    private void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
