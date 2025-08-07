using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeTankPuzzle : MonoBehaviour
{

    public int oneMax = 100;
    public int oneStart = 50;
    public int oneCurrent = 50;
    public int twoMax = 100;
    public int twoStart = 50;
    public int twoCurrent = 50;
    public int threeMax = 100;
    public int threeStart = 50;
    public int threeCurrent = 50;

    public int transferValue = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check value logic goes here
        //call up puzzle display canvas
        //select a tank to drain & a tank to fill
        //tankTransfer();
        //solveConditions();

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

    //void solveConditions()
    //{
    //win resolution goes here - door unlocked/
    //}
}
