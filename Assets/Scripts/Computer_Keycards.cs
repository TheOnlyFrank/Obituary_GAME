using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Keycards : MonoBehaviour
{

    [SerializeField] GameObject Computer_Keycards_Canvas;
    [SerializeField] GameObject Computer_Trigger;
    public Inventory_Manager inventory;
    public bool blank_Card;
    public bool pilot_Card;
    //public AudioClip noCardSound;

    //private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        Computer_Keycards_Canvas.SetActive(true);
        blank_Card = false;
        pilot_Card = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (blank_Card && pilot_Card)
        {
            inventory.has_Blank_Key = false;
            inventory.has_Co_Pilot_Key = true;
            Computer_Keycards_Canvas.SetActive(false);
            Destroy(Computer_Trigger);

        }
    }

    public void Blank_Card_Button()
    {
        if (inventory.has_Blank_Key)
        {
            blank_Card = true;

        }
        else
        {
            //PlayAudioEffect(noCardSound);
        }
    }

    public void Pilot_Card_Button()
    {
        if (inventory.has_Pilot_Key)
        {
            pilot_Card = true;

        }
        else
        {
            //PlayAudioEffect(noCardSound);
        }
    }
}

