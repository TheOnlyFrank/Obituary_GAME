using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerKeycards : MonoBehaviour
{

    [SerializeField] GameObject ComputerKeycardsCanvas;
    [SerializeField] GameObject ComputerTrigger;
    public GameInventoryManager inventory;
    public bool blankCard;
    public bool coPilotCard;
    //public AudioClip noCardSound;

    //private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        ComputerKeycardsCanvas.SetActive(true);
        blankCard = false;
        coPilotCard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (blankCard && coPilotCard)
        {
            inventory.hasBlankKey = false;
            inventory.hasPilotKey = true;
            ComputerKeycardsCanvas.SetActive(false);
            Destroy(ComputerTrigger);

        }
    }

    public void BlankCard_Button()
    {
        if (inventory.hasBlankKey)
        {
            blankCard = true;

        }
        else
        {
            //PlayAudioEffect(noCardSound);
        }
    }

    public void CoPilotCardButton()
    {
        if (inventory.hasCoPilotKey)
        {
            coPilotCard = true;

        }
        else
        {
            //PlayAudioEffect(noCardSound);
        }
    }
}

