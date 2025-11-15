using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class GeneratorPuzzle : MonoBehaviour
{

    [SerializeField] GameObject Generator_Puzzle_Canvas;
    [SerializeField] GameObject Unpowered_Door;
    [SerializeField] GameObject Unpowered_Door_Trigger;
    [SerializeField] GameObject Reactor_Trigger;
    
    
    public bool switchOne;
    public bool switchTwo;
    public bool switchThree;
    public GameObject lightOne;
    public GameObject lightTwo;
    public GameObject lightThree;
    public Sprite onSprite;
    public Sprite offSprite;
    

    // Start is called before the first frame update
    void Start()
    {

        switchOne = false;
        lightThree.GetComponent<Image>().sprite = offSprite;
        switchTwo = false;
        lightThree.GetComponent<Image>().sprite = onSprite;
        switchThree = false;
        lightThree.GetComponent<Image>().sprite = offSprite;
    }

    // Update is called once per frame
    void Update()
    {

        solve_Conditions();

    }

    public void Switch_One_Button()
    {
        if (switchOne == true)
        {
            switchOne = false;
            lightOne.GetComponent<Image>().sprite = offSprite;
        }
        else
        {
            switchOne = true;
            lightOne.GetComponent<Image>().sprite = onSprite;
        }
    }

    public void Switch_Two_Button()
    {
        if (switchTwo == true)
        {
            switchTwo = false;
            lightTwo.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            switchTwo = true;
            lightTwo.GetComponent<Image>().sprite = offSprite;
        }
    }

    public void Switch_Three_Button()
    {
        if (switchThree == true)
        {
            switchThree = false;
            lightThree.GetComponent<Image>().sprite = offSprite;
        }
        else
        {
            switchThree = true;
            lightThree.GetComponent<Image>().sprite = onSprite;
        }
    }

    

    void solve_Conditions()
    {
    if (switchOne == true && switchTwo == true && switchThree == true)
        {
            Debug.Log("Puzzle Solved!");

                    Invoke("Delay", 2); 
                    Generator_Puzzle_Canvas.SetActive(false);
                    Unpowered_Door.GetComponent<Door_Controller>().enabled = true;
                    Debug.Log("Power Restored!");
                    Destroy(Reactor_Trigger);
                    Destroy(Unpowered_Door_Trigger);
        }
    }

   
}
