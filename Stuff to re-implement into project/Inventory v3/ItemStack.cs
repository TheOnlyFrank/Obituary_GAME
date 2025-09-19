using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public struct ItemStack
{

    [field:SerializeField] public ItemClass Item {get; private set;}
    [field:SerializeField] public int Quanity {get; private set;}
}
