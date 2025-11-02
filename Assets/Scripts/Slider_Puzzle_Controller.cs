using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Puzzle_Controller : MonoBehaviour
{
    [SerializeField] GameObject Slider_Puzzle_Canvas;
    [SerializeField] GameObject Crew_Cryo_Door;
    [SerializeField] GameObject Crew_Cryo_Trigger;

    public bool winCondition;
    public GameObject light;
    public Sprite redLight;
    public Sprite greenLight;

    public Slider N2Slider;
    public Slider O2Slider;
    public Slider N2OSlider;
    public Slider H2OSlider;

    public float N2Correct;
    public float O2Correct;
    public float N2OCorrect;
    public float H2OCorrect;

    // Start is called before the first frame update
    void Start()
    {
        winCondition = false;
        Slider_Puzzle_Canvas.SetActive(true);

        light.GetComponent<Image>().sprite = redLight;


        CheckSliderValue();
    }

    void Update()
    {
        winChecker();
    }



    public void CheckSliderValue()
    {
        if (N2Slider != null)
        {
            if (N2Slider.value == N2Correct)
            {
                Debug.Log("Slider Value is correct: " + N2Correct);
            }
            else
            {
                Debug.Log("Slider Value is not correct: " + N2Slider.value + ", instead of the correct value: " + N2Correct);
            }
        }
        else
        {
            Debug.Log("Slider reference not set in Inspector!");
        }

        if (O2Slider != null)
        {
            if (O2Slider.value == O2Correct)
            {
                Debug.Log("Slider Value is correct: " + O2Correct);
            }
            else
            {
                Debug.Log("Slider Value is not correct: " + O2Slider.value + ", instead of the correct value: " + O2Correct);
            }
        }
        else
        {
            Debug.Log("Slider reference not set in Inspector!");
        }

        if (N2OSlider != null)
        {
            if (N2OSlider.value == N2OCorrect)
            {
                Debug.Log("Slider Value is correct: " + N2OCorrect);
            }
            else
            {
                Debug.Log("Slider Value is not correct: " + N2OSlider.value + ", instead of the correct value: " + N2OCorrect);
            }
        }
        else
        {
            Debug.Log("Slider reference not set in Inspector!");
        }

        if (H2OSlider != null)
        {
            if (H2OSlider.value == H2OCorrect)
            {
                Debug.Log("Slider Value is correct: " + H2OCorrect);
            }
            else
            {
                Debug.Log("Slider Value is not correct: " + H2OSlider.value + ", instead of the correct value: " + H2OCorrect);
            }
        }
        else
        {
            Debug.Log("Slider reference not set in Inspector!");
        }
    }


    void OnEnable()
    {
        if (N2Slider != null)
        {
            N2Slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        }

        if (O2Slider != null)
        {
            O2Slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        }

        if (N2OSlider != null)
        {
            N2OSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        }

        if (H2OSlider != null)
        {
            H2OSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        }
    }

    void OnDisable()
    {
        if (N2Slider != null)
        {
            N2Slider.onValueChanged.RemoveListener(delegate { OnSliderValueChanged(); });
        }

        if (O2Slider != null)
        {
            O2Slider.onValueChanged.RemoveListener(delegate { OnSliderValueChanged(); });
        }

        if (N2OSlider != null)
        {
            N2OSlider.onValueChanged.RemoveListener(delegate { OnSliderValueChanged(); });
        }

        if (H2OSlider != null)
        {
            H2OSlider.onValueChanged.RemoveListener(delegate { OnSliderValueChanged(); });
        }
    }

    public void OnSliderValueChanged()
    {
        CheckSliderValue();
    }

    void winChecker()
    {
        if (N2OSlider.value == N2OCorrect && N2Slider.value == N2Correct && O2Slider.value == O2Correct && H2OSlider.value == H2OCorrect)
        {
            winCondition = true;
            light.GetComponent<Image>().sprite = greenLight;
            Debug.Log("Puzzle Solved!");
            
            Invoke("Delay", 2);
        }
    }

    void Delay()
    {
        Slider_Puzzle_Canvas.SetActive(false);
        Crew_Cryo_Door.GetComponent<Door_Controller>().enabled = true;
        Destroy(Crew_Cryo_Trigger);
    }
}
