using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Level : MonoBehaviour
{

    public void Main_Menu_Button()
    {
        SceneManager.LoadScene("Menu_Scene", LoadSceneMode.Single);
    }

    public void Exit_Button()
    {
        // Quit Game
        Application.Quit();
    }

}
