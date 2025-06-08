using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Controls : MonoBehaviour
{

    [SerializeField] GameObject Bridge_Canvas;
    [SerializeField] GameObject Airlock_Door;
    [SerializeField] GameObject Comms_Screen;
    [SerializeField] GameObject Airlock_Screen;
    [SerializeField] GameObject Airlock_Trigger;
    [SerializeField] GameObject Outside_Light;
    [SerializeField] GameObject All_Triggers;

    public Inventory_Manager inventory;
    public bool cP_Card;
    public bool P_Card;


    // Start is called before the first frame update
    void Start()
    {
        Bridge_Canvas.SetActive(true);
        Airlock_Screen.SetActive(false);
        //Pilot_Card = false;
        //co_Pilot_Card = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pilot_Card_Button()
    {
        if (inventory.has_Pilot_Key)
        {
            P_Card = true;
            Debug.Log("Pilot Card inserted");
            //DisableButton();
        }
        else
        {
            Debug.Log("Button Pressed, no card found");
            //PlayAudioEffect(noCardSound);
        }
    }

    public void Co_Pilot_Card_Button()
    {
        if (inventory.has_Co_Pilot_Key)
        {
            cP_Card = true;
            Debug.Log("Co-Pilot Card inserted");
            //DisableButton();
        }
        else
        {
            Debug.Log("Button Pressed, no card found");
            //PlayAudioEffect(noCardSound);
        }
    }

    public void Beacon_Button()
    {
        if (cP_Card) //&& Pilot_Card)
        {
            Comms_Screen.SetActive(false);
            Airlock_Screen.SetActive(true);
            Debug.Log("Beacon Button Pressed");
            All_Triggers.SetActive(false);

        }
        else
        {
            Debug.Log("Button Pressed, no cards found");
            //PlayAudioEffect(noCardSound);
        }
    }

    //public void DisableButton()
    //{
    //    Button btn = GameObject.FindGameObjectWithTag("Bridge_Computer").GetComponent<Button>();
    //    btn.Interactable = false;
    //}
    //
    //public void Enable_Button()
    //{
    //    Button btn = GameObject.FindGameObjectWithTag("Bridge_Computer").GetComponent<Button>();
    //    btn.Interactable = false;
    //}

    public void Airlock_Button()
    {
        Airlock_Door.GetComponent<Auto_Door>().enabled = true;
        Bridge_Canvas.SetActive(false);
        Outside_Light.SetActive(true);
        Destroy(Airlock_Trigger);
    }

}
