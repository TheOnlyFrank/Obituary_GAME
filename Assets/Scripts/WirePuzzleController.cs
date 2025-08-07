using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WirePuzzleController : MonoBehaviour
{
    [SerializeField] GameObject WirePuzzleCanvas;
    [SerializeField] GameObject SpecificDoor;
    
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
        WirePuzzleCanvas.SetActive(true);
       // Time.timeScale = 0;
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
        if (redLight.GetComponent<UnpoweredWire>().lightOn)
        {
            redCheck = true;
            redLight.GetComponent<UnpoweredWire>().lightOn = false;
        }
    }

    void greenChecker()
    {
        if (greenLight.GetComponent<UnpoweredWire>().lightOn)
        {
            greenCheck = true;
            greenLight.GetComponent<UnpoweredWire>().lightOn = false;
        }
    }

    void blueChecker()
    {
        if (blueLight.GetComponent<UnpoweredWire>().lightOn)
        {
            blueCheck = true;
            blueLight.GetComponent<UnpoweredWire>().lightOn = false;
        }
    }
    
    void winChecker()
    {
        if (redCheck && greenCheck && blueCheck)
        {
            winCondition = true;
            Debug.Log("Puzzle solved correctly!");
            WirePuzzleCanvas.SetActive(false);
            SpecificDoor.GetComponent<AutoDoor>().enabled = true;
           // Time.timeScale = 1;
        }
    }
}
