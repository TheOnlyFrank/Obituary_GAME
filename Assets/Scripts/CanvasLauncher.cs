using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLauncher : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject thisCanvas;
    [SerializeField] GameObject prompt;

    // Start is called before the first frame update
    void Start()
    {
        thisCanvas.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    
    //}

    public void OnPlayerInteract()
    {
        if (thisCanvas.activeSelf)
        {
            Debug.Log("Canvas is already active, deactivating.");
            thisCanvas.SetActive(false);
        }
        else
        {
            Debug.Log("Canvas launching!");
            thisCanvas.SetActive(true);
            prompt.SetActive(false);
        }

    }
}
