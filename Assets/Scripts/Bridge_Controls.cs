using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Controls : MonoBehaviour
{

    [SerializeField] GameObject BridgeCanvas;
    [SerializeField] GameObject AirlockDoor;
    [SerializeField] GameObject CommsScreen;
    [SerializeField] GameObject AirlockScreen;
    [SerializeField] GameObject AirlockTrigger;
    [SerializeField] GameObject OutsideLight;
    [SerializeField] GameObject AllTriggers;

    public Inventory_Manager inventory;
    public bool cP_Card;
    public bool P_Card;


    // Start is called before the first frame update
    void Start()
    {
        BridgeCanvas.SetActive(true);
        AirlockScreen.SetActive(false);
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
            CommsScreen.SetActive(false);
            AirlockScreen.SetActive(true);
            Debug.Log("Beacon Button Pressed");
            AllTriggers.SetActive(false);

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
        AirlockDoor.GetComponent<Door_Controller>().enabled = true;
        BridgeCanvas.SetActive(false);
        OutsideLight.SetActive(true);
        Destroy(AirlockTrigger);
    }

}
