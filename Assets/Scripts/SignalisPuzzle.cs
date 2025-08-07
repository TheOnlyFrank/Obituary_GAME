using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SignalisPuzzle : MonoBehaviour
{

    [SerializeField] GameObject SignalisPuzzleCanvas;
    [SerializeField] GameObject SignalisPuzzleCanvas2;
    [SerializeField] GameObject CrewCryoDoor;
    [SerializeField] GameObject UnpoweredDoor;
    [SerializeField] GameObject DirectionalLight;
    [SerializeField] GameObject CrewCryoTrigger;
    [SerializeField] GameObject ReactorTrigger;
    [SerializeField] TextMeshProUGUI TankOneValue;
    [SerializeField] TextMeshProUGUI TankTwoValue;
    [SerializeField] TextMeshProUGUI TankThreeValue;

    
    public int oneMax = 1200;
    public int oneStart = 1200;
    public int oneCurrent;
    public int twoMax = 800;
    public int twoStart = 0;
    public int twoCurrent;
    public int threeMax = 500;
    public int threeStart = 0;
    public int threeCurrent;

    public int transferValue = 0;




    // Start is called before the first frame update
    void Start()
    {

        if (this.tag == "CrewCryo")
        {
            SignalisPuzzleCanvas.SetActive(true);
        }
        else
        {
            if (this.tag == "Reactor")
            {
            SignalisPuzzleCanvas2.SetActive(true);
            }
        }
        oneCurrent = oneStart;
        twoCurrent = twoStart;
        threeCurrent = threeStart;
    }

    // Update is called once per frame
    void Update()
    {
        TankOneValue.text = oneCurrent.ToString();
        TankTwoValue.text = twoCurrent.ToString();
        TankThreeValue.text = threeCurrent.ToString();
        //check value logic goes here
        //call up puzzle display canvas
        //select a tank to drain & a tank to fill
        //tankTransfer();
        solveConditions();

    }

    public void OneToTwoButton()
    {
        if ((oneCurrent + twoCurrent) >= twoMax)
        {
            transferValue = ((oneCurrent + twoCurrent) - twoMax);
            Debug.Log("Transfer value =" + transferValue);
            twoCurrent = twoMax;
            oneCurrent = transferValue;
            transferValue = 0;
        }
        else
        {
            twoCurrent = (oneCurrent + twoCurrent);
            oneCurrent = (oneCurrent - oneCurrent);
        }
    }

    public void OneToThreeButton()
    {
        if ((oneCurrent + threeCurrent) >= threeMax)
        {
            transferValue = ((oneCurrent + threeCurrent) - threeMax);
            threeCurrent = threeMax;
            oneCurrent = transferValue;
            transferValue = 0;
        }
        else
        {
            threeCurrent = (oneCurrent + threeCurrent);
            oneCurrent = (oneCurrent - oneCurrent);
        }
    }

    public void TwoToOneButton()
    {
        if ((twoCurrent + oneCurrent) >= oneMax)
        {
            transferValue = ((twoCurrent + oneCurrent) - oneMax);
            oneCurrent = oneMax;
            twoCurrent = transferValue;
            transferValue = 0;
        }
        else
        {
            oneCurrent = (twoCurrent + oneCurrent);
            twoCurrent = (twoCurrent - twoCurrent);
        }
    }

    public void TwoToThreeButton()
    {
        if ((twoCurrent + threeCurrent) >= threeMax)
        {
            transferValue = ((twoCurrent + threeCurrent) - threeMax);
            threeCurrent = threeMax;
            twoCurrent = transferValue;
            transferValue = 0;
        }
        else
        {
            threeCurrent = (twoCurrent + threeCurrent);
            twoCurrent = (twoCurrent - twoCurrent);
        }
    }

    public void ThreeToOneButton()
    {
        if ((threeCurrent + oneCurrent) >= oneMax)
        {
            transferValue = ((threeCurrent + oneCurrent) - oneMax);
            oneCurrent = oneMax;
            threeCurrent = transferValue;
            transferValue = 0;
        }
        else
        {
            oneCurrent = (threeCurrent + oneCurrent);
            threeCurrent = (threeCurrent - threeCurrent);
        }
    }

    public void ThreeToTwoButton()
    {
        if ((threeCurrent + twoCurrent) >= twoMax)
        {
            transferValue = ((threeCurrent + twoCurrent) - twoMax);
            twoCurrent = twoMax;
            threeCurrent = transferValue;
            transferValue = 0;
        }
        else
        {
            twoCurrent = (threeCurrent + twoCurrent);
            threeCurrent = (threeCurrent - threeCurrent);
        }
    }

    //void tankTransfer()
    //{
    //transferValue = (selected tank "current" + target tank "current");
    //if transferValue >= target tank "max"
    //{
    //selected tank "current" = (transferValue - target tank "max");
    //target tank "current" = target tank "max";
    //transferValue = 0;
    //}
    //else
    //{
    //target tank "current" = transferValue;
    //if (selected tank "current" - transferValue) >= 0
    //{
    //selected tank "current" = (selected tank "current" - transferValue);
    //}
    //else
    //{
    //selected tank "current" = 0;
    //}
    //transferValue = 0;
    //}
    //}

    void solveConditions()
    {
    if (oneCurrent == twoCurrent)
        {
            Debug.Log("Puzzle Solved!");
            
            if (this.tag == "CrewCryo")
            {
                SignalisPuzzleCanvas.SetActive(false);
                CrewCryoDoor.GetComponent<AutoDoor>().enabled = true;
                Debug.Log("Crew Cryo Door Unlocked!");
                Destroy(CrewCryoTrigger);
            }
            else
            {
                if (this.tag == "Reactor")
                {
                    SignalisPuzzleCanvas2.SetActive(false);
                    UnpoweredDoor.GetComponent<AutoDoor>().enabled = true;
                    Destroy(DirectionalLight);
                    SceneManager.LoadScene("PoweredLighting", LoadSceneMode.Additive);
                    Debug.Log("Power Restored!");
                    Destroy(ReactorTrigger);
                }
            }

        }
    }
}
