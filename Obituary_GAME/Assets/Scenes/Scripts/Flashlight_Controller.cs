using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class Flashlight_Controller : MonoBehaviour
{
    // Public variables
    public AudioClip turnOnSound;
    public AudioClip turnOffSound;
 

    // Private variables
    private Light flash_light;
    private AudioSource audioSource;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private CharacterController controller;
    private inputAction flashlight;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
 
    }

    private void Start()
    {
        // Get Light component in the same GameObject
        flash_light = GetComponent<Light>();

        if (flash_light == null)
        {
            Debug.LogWarning("Light component is not attached. Attach a Light component manually.");
        }
        else
        {
            flash_light.enabled = false;
        }

        // Get or add AudioSource component to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {

        HandleInput();
        Flashlight_Toggle();
    }

    void HandleInput()
    {
        flashlight = playerControls.Controls.Flashlight.ReadValueAsObject(); 
            //What is the type that needs to go in, or replace, the "ReadValue()" element???? It's not a Vector2, float, or bool!?!?!?!?
    }

    void Flashlight_Toggle()
    {
//        //Toggle code goes here!

        var flashy = playerInput.actions["Flashlight"];
        if (flashy.IsPressed())
        if (playerInput.actions["Flashlight"].WasPressedThisFrame())
        {
            if (flash_light != null)
            {
                flash_light.enabled = !flash_light.enabled;

                // Play audio effect based on flashlight state
                if (flash_light.enabled)
                {
                    PlayAudioEffect(turnOnSound);
                }
                else
                {
                    PlayAudioEffect(turnOffSound);
                }
            }
            else
            {
                Debug.LogWarning("Cannot control flashlight as Light component is not attached.");
            }
        }
    }


    private void PlayAudioEffect(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}