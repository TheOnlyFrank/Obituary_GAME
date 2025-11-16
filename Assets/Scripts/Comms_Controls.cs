using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comms_Controls : MonoBehaviour
{
    [SerializeField] public GameObject CommsCanvas;
    [SerializeField] public GameObject EnableCommsScreen;
    [SerializeField] public GameObject TuningScreen;
    [SerializeField] public GameObject RBTriggers;
    [SerializeField] public GameObject Comms_Online;

    [SerializeField] private Slider TuningSlider;
    [SerializeField] GameObject EndGame_Trigger;

    public GameObject mantisPrefab;
    
    public Text valueText;

    public float CorrectTune;

    public bool winCondition;

    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        CommsCanvas.SetActive(true);
        EnableCommsScreen.SetActive(true);
        TuningScreen.SetActive(false);
        Comms_Online.SetActive(false);
        StartCoroutine(EnemyDrop());
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
            UpdateSliderValueDisplay(TuningSlider.value);
            
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

    public void UpdateSliderValueDisplay(float newValue)
    {
        valueText.text = newValue.ToString("0");
    }

    void winChecker()
    {
        if(TuningSlider.value == CorrectTune)
        {
            winCondition = true; 
            Debug.Log("Puzzle is Solved!");
            CommsCanvas.SetActive(false);

            Comms_Online.SetActive(true);

            Invoke("Delay", 3);

            RBTriggers.SetActive(false);
            EndGame_Trigger.SetActive(true);

            EnemyDrop();
        }
    }

    void Delay()
    {
        Comms_Online.SetActive(false);
    }

    public IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(-169, -105);
            zPos = Random.Range(-15, -6);
            Instantiate(mantisPrefab, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
