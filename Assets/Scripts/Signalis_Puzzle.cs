using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.SceneManagement;

public class Signalis_Puzzle : MonoBehaviour
{

    [SerializeField] GameObject Signalis_Puzzle_Canvas;
    [SerializeField] GameObject Signalis_Puzzle_Canvas_2;
    [SerializeField] GameObject Crew_Cryo_Door;
    [SerializeField] GameObject Unpowered_Door;
    [SerializeField] GameObject Directional_Light;
    [SerializeField] GameObject Crew_Cryo_Trigger;
    [SerializeField] GameObject Reactor_Trigger;
    [SerializeField] TextMeshProUGUI TankOneValue;
    [SerializeField] TextMeshProUGUI TankTwoValue;
    [SerializeField] TextMeshProUGUI TankThreeValue;

    
    public int one_Max = 1200;
    public int one_Start = 1200;
    public int one_Current;
    public int two_Max = 800;
    public int two_Start = 0;
    public int two_Current;
    public int three_Max = 500;
    public int three_Start = 0;
    public int three_Current;

    public int transfer_Value = 0;




    // Start is called before the first frame update
    void Start()
    {

        if (this.tag == "Crew_Cryo")
        {
            Signalis_Puzzle_Canvas.SetActive(true);
        }
        else
        {
            if (this.tag == "Reactor")
            {
            Signalis_Puzzle_Canvas_2.SetActive(true);
            }
        }
        one_Current = one_Start;
        two_Current = two_Start;
        three_Current = three_Start;
    }

    // Update is called once per frame
    void Update()
    {
        TankOneValue.text = one_Current.ToString();
        TankTwoValue.text = two_Current.ToString();
        TankThreeValue.text = three_Current.ToString();
        //check value logic goes here
        //call up puzzle display canvas
        //select a tank to drain & a tank to fill
        //tank_Transfer();
        solve_Conditions();

    }

    public void One_To_Two_Button()
    {
        if ((one_Current + two_Current) >= two_Max)
        {
            transfer_Value = ((one_Current + two_Current) - two_Max);
            Debug.Log("Transfer value =" + transfer_Value);
            two_Current = two_Max;
            one_Current = transfer_Value;
            transfer_Value = 0;
        }
        else
        {
            two_Current = (one_Current + two_Current);
            one_Current = (one_Current - one_Current);
        }
    }

    public void One_To_Three_Button()
    {
        if ((one_Current + three_Current) >= three_Max)
        {
            transfer_Value = ((one_Current + three_Current) - three_Max);
            three_Current = three_Max;
            one_Current = transfer_Value;
            transfer_Value = 0;
        }
        else
        {
            three_Current = (one_Current + three_Current);
            one_Current = (one_Current - one_Current);
        }
    }

    public void Two_To_One_Button()
    {
        if ((two_Current + one_Current) >= one_Max)
        {
            transfer_Value = ((two_Current + one_Current) - one_Max);
            one_Current = one_Max;
            two_Current = transfer_Value;
            transfer_Value = 0;
        }
        else
        {
            one_Current = (two_Current + one_Current);
            two_Current = (two_Current - two_Current);
        }
    }

    public void Two_To_Three_Button()
    {
        if ((two_Current + three_Current) >= three_Max)
        {
            transfer_Value = ((two_Current + three_Current) - three_Max);
            three_Current = three_Max;
            two_Current = transfer_Value;
            transfer_Value = 0;
        }
        else
        {
            three_Current = (two_Current + three_Current);
            two_Current = (two_Current - two_Current);
        }
    }

    public void Three_To_One_Button()
    {
        if ((three_Current + one_Current) >= one_Max)
        {
            transfer_Value = ((three_Current + one_Current) - one_Max);
            one_Current = one_Max;
            three_Current = transfer_Value;
            transfer_Value = 0;
        }
        else
        {
            one_Current = (three_Current + one_Current);
            three_Current = (three_Current - three_Current);
        }
    }

    public void Three_To_Two_Button()
    {
        if ((three_Current + two_Current) >= two_Max)
        {
            transfer_Value = ((three_Current + two_Current) - two_Max);
            two_Current = two_Max;
            three_Current = transfer_Value;
            transfer_Value = 0;
        }
        else
        {
            two_Current = (three_Current + two_Current);
            three_Current = (three_Current - three_Current);
        }
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

    void solve_Conditions()
    {
    if (one_Current == two_Current)
        {
            Debug.Log("Puzzle Solved!");
            
            if (this.tag == "Crew_Cryo")
            {
                Signalis_Puzzle_Canvas.SetActive(false);
                Crew_Cryo_Door.GetComponent<Door_Controller>().enabled = true;
                Debug.Log("Crew Cryo Door Unlocked!");
                Destroy(Crew_Cryo_Trigger);
            }
            else
            {
                if (this.tag == "Reactor")
                {
                    Signalis_Puzzle_Canvas_2.SetActive(false);
                    Unpowered_Door.GetComponent<Door_Controller>().enabled = true;
                    Destroy(Directional_Light);
                    //SceneManager.LoadScene("Powered_Lighting", LoadSceneMode.Additive);
                    Debug.Log("Power Restored!");
                    Destroy(Reactor_Trigger);
                }
            }

        }
    }
}
