using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuse_Puzzle_Controller : MonoBehaviour
{
    [SerializeField] public GameObject fusePuzzle_Canvas;
    [SerializeField] public Slider lever;
    [SerializeField] public GameObject commsDoor;
    [SerializeField] public GameObject winDialogue;
    
    public GameObject fbTriggers;
    public GameObject comDoorTrigger;
    public GameObject consoleTrigger;

    private int sliderCorrect = 1;

    public int interactionLimit = 7;
    public int currentInteractions = 0;

    // Start is called before the first frame update
    public void Start()
    {
        fusePuzzle_Canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentInteractions == interactionLimit)
        {
            Win();
        }
    }

    public void Complete_Fuse_Box()
    {
        if (lever != null)
        {
            if (lever.value == sliderCorrect)
            {
                Debug.Log("Slider Value is correct: " + sliderCorrect);
                fusePuzzle_Canvas.SetActive(false);
                AddInteraction(1);
            }
            else
            {
                Debug.Log("Slider Value is not correct: " + lever.value + ", instead of the correct value: " + sliderCorrect);
            }
        }
        else
        {
            Debug.Log("Slider reference not set in Inspector!");
        }
        ResetSlider();
    }

    void OnEnable()
    {
        if (lever != null)
        {
            lever.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        }
    }

    void OnDisable()
    {
        if (lever != null)
        {
            lever.onValueChanged.RemoveListener(delegate { OnSliderValueChanged(); });
        }
    }

    public void OnSliderValueChanged()
    {
       Complete_Fuse_Box();
    }

    public void ResetSlider()
    {
        if (lever.value != null)
        {
            lever.value = 0f;
        }
        else
        {
            Debug.Log("Slider not assigned in Inspector");
        }
    }

    public void Win()
    {
        Debug.Log("Power is on!");

        fbTriggers.SetActive(false);
        fusePuzzle_Canvas.SetActive(false);
        winDialogue.SetActive(true);
        commsDoor.SetActive(false);
        comDoorTrigger.SetActive(false);

        Invoke("Delay", 3);
    }

    void Delay()
    {
        winDialogue.SetActive(false);
        consoleTrigger.SetActive(false);
    }

    public void AddInteraction(int amount)
    {
        currentInteractions += amount;
    }
}
