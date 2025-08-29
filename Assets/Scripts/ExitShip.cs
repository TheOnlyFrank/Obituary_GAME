using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShip : MonoBehaviour
{
    
    [SerializeField] GameObject thisCanvas;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("End of Level Canvas launching!");
            thisCanvas.SetActive(true);
        }
    }
}
