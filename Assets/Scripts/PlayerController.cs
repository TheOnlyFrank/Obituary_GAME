using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour//, IDataPersistence
{
    // Public variables
    public AudioClip turnOnSound;
    public AudioClip turnOffSound;
    public AudioClip accessDeniedSound;
    public GameInventoryManager inventory;
    public SwitchScene switchScene;
    public GameObject InventoryCanvas;
    //public GameObject MedBayCanvas;

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
        InventoryCanvas.SetActive(false);
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
        if (inventory.hasFlashlight)
        {
            if (playerInput.actions["Flashlight"].WasPressedThisFrame())
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
        if (playerInput.actions["InventoryMenu"].WasPressedThisFrame())
        {
            if (InventoryCanvas.activeSelf)
            {
                InventoryCanvas.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                InventoryCanvas.SetActive(true);
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
        if (other.tag == "AutoDoor")
        {
            if (other.GetComponent<AutoDoor>().movingOut == false)
            {
                other.GetComponent<AutoDoor>().movingOut = true;
            }
        }
        else
        {
            if (other.tag == "ReactorDoor")
            {
                if (inventory.hasReactorKey)
                {
                    if (other.GetComponent<ReactorDoor>().movingOut == false)
                    {
                        other.GetComponent<ReactorDoor>().movingOut = true;
                    }
                }
                else
                {
                    PlayAudioEffect(accessDeniedSound);
                }
            }
            else
            {
                if (other.tag == "LockedDoor")
                {
                    if (inventory.hasCoPilotKey)
                    {
                        if (other.GetComponent<LockedDoor>().movingOut == false)
                        {
                            other.GetComponent<LockedDoor>().movingOut = true;
                        }
                    }
                    else
                    {
                        PlayAudioEffect(accessDeniedSound);
                    }
                }
                else
                {
                    if (other.tag == "BlankKey")
                    {
                        inventory.hasBlankKey = true;
                        Debug.Log("You got the Blank key!");
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        if (other.tag == "Co-PilotKey")
                        {
                            inventory.hasCoPilotKey = true;
                            Debug.Log("You got the Co-Pilot key!");
                            Destroy(other.gameObject);
                        }
                        else
                        {
                            if (other.tag == "Flashlight")
                            {
                                inventory.hasFlashlight = true;
                                Debug.Log("You got the flashlight!");
                                Destroy(other.gameObject);
                            }
                            else
                            {
                                if (other.tag == "ReactorKey")
                                {
                                    inventory.hasReactorKey = true;
                                    Debug.Log("You got the Reactor key!");
                                    Destroy(other.gameObject);
                                }
                            }
                        }
                    }
                }
            }
        }

    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if ((other.tag == "WireBox") && (playerInput.actions["Interact"].WasPressedThisFrame()))
    //     {
    //         Debug.Log("Interact button pressed");
    //         //switchScene.ChangeScene();
    //         //SaveData();
    //         SceneManager.LoadScene("WirePuzzle", LoadSceneMode.Single);
    //     }
    //     else
    //     {
    //         if ((other.tag == "MedBayRubble") && (playerInput.actions["Interact"].WasPressedThisFrame()))
    //         {
    //             Debug.Log("Interact button pressed");
    //             MedBayCanvas.SetActive(true);
    //         }
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //    if ((other.tag == "MedBayRubble"))
    //         {
    //             Debug.Log("Player exited trigger");
    //             MedBayCanvas.SetActive(false);
    //         }
    // }

    //public void LoadData(GameData data)
    //{
    //    this.transform.position = data.playerPosition;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.playerPosition = this.transform.position;
    //}
}
