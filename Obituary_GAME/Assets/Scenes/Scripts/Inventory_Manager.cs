using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{

    public bool has_Key = false;

    public bool has_Gun = false;
    public bool has_Melee = false;
    public bool has_Flashlight = false;

    public int ammo = 10;

    public int health_Packs = 0;


    // Start is called before the first frame update
    void Start()
    {
        has_Key = false;
        has_Gun = false;
        has_Melee = false;
        has_Flashlight = false;

}


}
