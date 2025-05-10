using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Get access to Unitys UI System
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    public GameObject canvas;

    private void Start() 
    {
        canvas.SetActive(false);
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
