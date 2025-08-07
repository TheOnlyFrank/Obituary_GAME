using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInventoryManager : MonoBehaviour
{

    public bool hasKey = false;
    public bool hasBlankKey = false;
    public bool hasCoPilotKey = false;
    public bool hasPilotKey = false;
    public bool hasReactorKey = false;
    public bool hasPistol = false;
    public bool hasShotgun = false;
    public bool hasMelee = false;
    public bool hasFlashlight = false;

    public int pistolAmmo = 0;
    public int shotgunAmmo = 0;
    public int healthPacks = 0;


    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        hasBlankKey = false;
        hasCoPilotKey = false;
        hasPilotKey = false;
        hasReactorKey = false;
        hasPistol = false;
        hasShotgun = false;
        hasMelee = false;
        hasFlashlight = false;

}


}
