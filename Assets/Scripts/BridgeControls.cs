using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControls : MonoBehaviour
{

    [SerializeField] GameObject Bridge_Canvas;
    [SerializeField] GameObject Airlock_Door;
    [SerializeField] GameObject Comms_Screen;
    [SerializeField] GameObject Airlock_Screen;
    [SerializeField] GameObject Airlock_Trigger;
    [SerializeField] GameObject Outside_Light;
    [SerializeField] GameObject All_Triggers;

    public GameInventoryManager inventory;
    public bool cPCard;
    public bool PCard;


    // Start is called before the first frame update
    void Start()
    {
        BridgeCanvas.SetActive(true);
        AirlockScreen.SetActive(false);
        //PilotCard = false;
        //coPilot_Card = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PilotCardButton()
    {
        if (inventory.hasPilotKey)
        {
            PCard = true;
            Debug.Log("Pilot Card inserted");
            //DisableButton();
        }
        else
        {
            Debug.Log("Button Pressed, no card found");
            //PlayAudioEffect(noCardSound);
        }
    }

    public void CoPilotCardButton()
    {
        if (inventory.hasCoPilotKey)
        {
            cPCard = true;
            Debug.Log("Co-Pilot Card inserted");
            //DisableButton();
        }
        else
        {
            Debug.Log("Button Pressed, no card found");
            //PlayAudioEffect(noCardSound);
        }
    }

    public void BeaconButton()
    {
        if (cPCard) //&& Pilot_Card)
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
        AirlockDoor.GetComponent<AutoDoor>().enabled = true;
        BridgeCanvas.SetActive(false);
        OutsideLight.SetActive(true);
        Destroy(AirlockTrigger);
    }

}
