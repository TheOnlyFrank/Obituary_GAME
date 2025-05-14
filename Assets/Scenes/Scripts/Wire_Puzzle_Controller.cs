using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wire_Puzzle_Controller : MonoBehaviour
{
    public bool redCheck;
    public bool greenCheck;
    public bool blueCheck;
    public bool winCondition;

    public GameObject redLight;
    public GameObject greenLight;
    public GameObject blueLight;

    // Start is called before the first frame update
    void Start()
    {
        redCheck = false;
        greenCheck = false;
        blueCheck = false;
        winCondition = false;
    }

    // Update is called once per frame
    void Update()
    {
        redChecker();
        greenChecker();
        blueChecker();
        winChecker();
    }

    void redChecker()
    {
        if (redLight.GetComponent<Unpowered_Wire>().lightOn)
        {
            redCheck = true;
            redLight.GetComponent<Unpowered_Wire>().lightOn = false;
        }
    }

    void greenChecker()
    {
        if (greenLight.GetComponent<Unpowered_Wire>().lightOn)
        {
            greenCheck = true;
            greenLight.GetComponent<Unpowered_Wire>().lightOn = false;
        }
    }

    void blueChecker()
    {
        if (blueLight.GetComponent<Unpowered_Wire>().lightOn)
        {
            blueCheck = true;
            blueLight.GetComponent<Unpowered_Wire>().lightOn = false;
        }
    }
    
    void winChecker()
    {
        if (redCheck && greenCheck && blueCheck)
        {
            winCondition = true;
            Debug.Log("Puzzle solved correctly!");
            SceneManager.LoadScene("Game_Scene");
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game_Scene"));
        }
    }
}
