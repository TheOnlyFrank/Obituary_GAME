using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker_Portal : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;
    //public Player player;
        

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.SetActive(false);
            Player.transform.position = teleportTarget.transform.position;
            Player.SetActive(true);
            Physics.SyncTransforms();
        }
    }


}
