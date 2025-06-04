using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{

    public bool has_Key = false;
    public bool has_Blank_Key = false;
    public bool has_Copilot_Key = false;
    public bool has_Reactor_Key = false;
    public bool has_Pistol = false;
    public bool has_Shotgun = false;
    public bool has_Melee = false;
    public bool has_Flashlight = false;

    public int pistol_Ammo = 0;
    public int shotgun_Ammo = 0;
    public int health_Packs = 0;


    // Start is called before the first frame update
    void Start()
    {
        has_Key = false;
        has_Blank_Key = false;
        has_Copilot_Key = false;
        has_Reactor_Key = false;
        has_Pistol = false;
        has_Shotgun = false;
        has_Melee = false;
        has_Flashlight = false;

}


}
