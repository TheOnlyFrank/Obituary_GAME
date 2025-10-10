using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comms_Controls : MonoBehaviour
{
    [SerializeField] public GameObject CommsCanvas;
    [SerializeField] public GameObject EPrompt;
    [SerializeField] public GameObject EnableCommsScreen;
    [SerializeField] public GameObject TuningScreen;
    [SerializeField] public GameObject RBTriggers;

    [SerializeField] private Slider TuningSlider;
    
    public float CorrectTune;

    public bool winCondition;

    // Start is called before the first frame update
    void Start()
    {
        CommsCanvas.SetActive(true);
        EPrompt.SetActive(false);
        EnableCommsScreen.SetActive(true);
        TuningScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        winChecker();
    }

    public void Enable_Comms()
    {
        EnableCommsScreen.SetActive(false);
        TuningScreen.SetActive(true);
    }

    public void TuningRadio()
    {
        if(TuningSlider.value != null)
        {
            if(TuningSlider.value == CorrectTune)
            {
                Debug.Log("Slider Value is correct: " + CorrectTune);
            }
            else
            {
                Debug.Log("Slider Value is not correct: " + TuningSlider.value + ", instead of the correct value: " + CorrectTune);
            }
        }
        else
        {
            Debug.Log("Slider reference not set in Inspector!");
        }
    }

    void OnEnable() 
    {
        if (TuningSlider != null)
        {
            TuningSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        }
    }

    void OnDisable()
    {
        if (TuningSlider != null)
        {
            TuningSlider.onValueChanged.RemoveListener(delegate { OnSliderValueChanged(); });
        }
    }

    public void OnSliderValueChanged()
    {
        TuningRadio();
    }

    void winChecker()
    {
        if(TuningSlider.value == CorrectTune)
        {
            winCondition = true; 
            Debug.Log("Puzzle is Solved!");
            CommsCanvas.SetActive(false);
            Destroy(RBTriggers);
        }
    }
}
