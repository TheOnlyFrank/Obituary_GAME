using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other) 
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
