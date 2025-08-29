using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class Player_Controls : MonoBehaviour//, I_Data_Persistence
{
    // Public variables
    public AudioClip turnOnSound;
    public AudioClip turnOffSound;
    public AudioClip accessDeniedSound;
    public AudioClip interactSound;
    public Inventory_Manager inventory;
    public SwitchScene switchScene;
    public GameObject Inventory_Canvas;
    

    // Private variables
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmoothing = 1000f;

    [SerializeField] private bool isGamepad;


    private Vector2 movement;
    private Vector2 aim;
    private Vector3 playerVelocity;

    private CharacterController controller;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private Light flashlight;
    private AudioSource audioSource;
    



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;
        Inventory_Canvas.SetActive(false);
    }

    void Start()
    {
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

    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
        HandleFlashlight();
        OpenInventory();
    }

    void HandleInput()
    {
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        var running = playerInput.actions["Run"];
        if (running.IsPressed())
        { moveSpeed = 6.0f; }
        else
        { moveSpeed = 3.0f; }

        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * moveSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void HandleRotation()
    {
        if (isGamepad)
        {
            //Rotate our player
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, gamepadRotateSmoothing * Time.deltaTime);
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(aim);
            Plane groundPlan = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlan.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
    }

    void HandleFlashlight()
    {
        if (playerInput.actions["Flashlight"].WasPressedThisFrame())
        {
            if (inventory.has_Flashlight)
            {
                if (flashlight.enabled == false)
                {
                    flashlight.enabled = true;
                    PlayAudioEffect(turnOnSound);
                }
                else
                {
                    flashlight.enabled = false;
                    PlayAudioEffect(turnOffSound);
                }
            }
        }
    }

    void OpenInventory()
    {
        if (playerInput.actions["Inventory_Menu"].WasPressedThisFrame())
        {
            if (Inventory_Canvas.activeSelf)
            {
                Inventory_Canvas.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Inventory_Canvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    private void PlayAudioEffect(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Auto_Door")
        {
            if (other.GetComponent<AutoDoor>().movingOut == false)
            {
                other.GetComponent<AutoDoor>().movingOut = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collision Entry Detected");
        
        if (playerInput.actions["Interact"].WasPressedThisFrame())
        {
            Debug.Log("Pre-Interaction Started");
            PlayAudioEffect(interactSound);
            if (other.TryGetComponent(out IInteractable interactableObject))
            {
                
                
                    interactableObject.OnPlayerInteract();
                    Debug.Log("Interaction Started");
                }
            }


        //else
        //{
        //    if (other.tag == "Reactor_Door")
        //    {
        //        if (inventory.has_Reactor_Key)
        //        {
        //            if (other.GetComponent<Reactor_Door>().moving_Out == false)
        //            {
        //                other.GetComponent<Reactor_Door>().moving_Out = true;
        //            }
        //        }
        //        else
        //        {
        //            PlayAudioEffect(accessDeniedSound);
        //        }
        //    }
        //    else
        //    {
        //        if (other.tag == "Locked_Door")
        //        {
        //            if (inventory.has_Co_Pilot_Key)
        //            {
        //                if (other.GetComponent<Locked_Door>().moving_Out == false)
        //                {
        //                    other.GetComponent<Locked_Door>().moving_Out = true;
        //                }
        //            }
        //            else
        //            {
        //                PlayAudioEffect(accessDeniedSound);
        //            }
        //        }
        //        else
        //        {
        //            if (other.tag == "Blank_Key")
        //            {
        //                inventory.has_Blank_Key = true;
        //                Debug.Log("You got the Blank key!");
        //                Destroy(other.gameObject);
        //            }
        //            else
        //            {
        //                if (other.tag == "Co-Pilot_Key")
        //                {
        //                    inventory.has_Co_Pilot_Key = true;
        //                    Debug.Log("You got the Co-Pilot key!");
        //                    Destroy(other.gameObject);
        //                }
        //                else
        //                {
        //                    if (other.tag == "Flashlight")
        //                    {
        //                        inventory.has_Flashlight = true;
        //                        Debug.Log("You got the flashlight!");
        //                        Destroy(other.gameObject);
        //                    }
        //                    else
        //                    {
        //                        if (other.tag == "Reactor_Key")
        //                        {
        //                            inventory.has_Reactor_Key = true;
        //                            Debug.Log("You got the Reactor key!");
        //                            Destroy(other.gameObject);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

    }


}
