using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu_Scene", LoadSceneMode.Single);
    }

    public void ExitButton()
    {
        // Quit Game
        Application.Quit();
    }

}
