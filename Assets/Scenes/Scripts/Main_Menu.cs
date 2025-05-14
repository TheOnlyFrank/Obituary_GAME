using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject StoryMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void NewGameButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void ContinueButton()
    //{
    //    // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Scene");
    //}

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        StoryMenu.SetActive(false);
    }

    public void StoryButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        StoryMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        StoryMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}