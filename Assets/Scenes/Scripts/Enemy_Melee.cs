using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject Punch;
    private bool attacking;


    private void Start()
    {
        attacking = false;
    }


    private void Update()
    {
        if (attacking)
        {
            Punch.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            Debug.Log("SWING!");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attacking = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attacking = false;
        }
    }
}
