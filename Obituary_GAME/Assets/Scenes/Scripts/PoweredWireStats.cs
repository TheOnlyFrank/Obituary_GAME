using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colour { blue, red, green, yellow};
public class PoweredWireStats : MonoBehaviour
{
    public bool movable = false;
    public bool moving = false;
    public Vector3 startPosition;
    public Colour objectColour;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
