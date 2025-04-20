using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three_Tank_Puzzle : MonoBehaviour
{

    public int one_Max = 100;
    public int one_Start = 50;
    public int one_Current = 50;
    public int two_Max = 100;
    public int two_Start = 50;
    public int two_Current = 50;
    public int three_Max = 100;
    public int three_Start = 50;
    public int three_Current = 50;

    public int transfer_Value = 0;



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
        //tank_Transfer();
        //solve_Conditions();

    }

    //void tank_Transfer()
    //{
    //transfer_Value = (selected tank "current" + target tank "current");
    //if transfer_Value >= target tank "max"
    //{
    //selected tank "current" = (transfer_Value - target tank "max");
    //target tank "current" = target tank "max";
    //transfer_Value = 0;
    //}
    //else
    //{
    //target tank "current" = transfer_Value;
    //if (selected tank "current" - transfer_Value) >= 0
    //{
    //selected tank "current" = (selected tank "current" - transfer_Value);
    //}
    //else
    //{
    //selected tank "current" = 0;
    //}
    //transfer_Value = 0;
    //}
    //}

    //void solve_Conditions()
    //{
    //win resolution goes here - door unlocked/
    //}
}
