using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Get access to Unitiys UI System
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    public Canvas EPromptCanvas;

    void OnTriggerEnter(Collider JohnEnteringWireTrigger)
    {
        if(JohnEnteringWireTrigger.tag == "Player")
        {
            Debug.Log("Player is by Wire Box");
            //show the E Prompt Canvas
            EPromptCanvas.enabled = true;
        }
    }
}
