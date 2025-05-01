using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Wire_Puzzle");
        }
    }
}
