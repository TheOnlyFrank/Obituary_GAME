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

    private int sliderCorrect = 1;

    public int interactionLimit = 7;
    public int currentInteractions = 0;

    private bool hasFunctionRun = false;

    // Start is called before the first frame update
    public void Start()
    {
        fusePuzzle_Canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Win();

        hasFunctionRun = true;
    }

    public void Complete_Fuse_Box()
    {
        if (lever != null)
        {
            if (lever.value == sliderCorrect)
            {
                Debug.Log("Slider Value is correct: " + sliderCorrect);
                fusePuzzle_Canvas.SetActive(false);
                currentInteractions++;
                ResetSlider();
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
        if (currentInteractions == interactionLimit)
        {
            Debug.Log("Power is on!");

            winDialogue.SetActive(true);
            commsDoor.SetActive(false);
        }
    }
}
