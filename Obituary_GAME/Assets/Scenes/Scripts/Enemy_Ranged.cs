using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : MonoBehaviour
{
    public GameObject cannon;
    public GameObject cannonBallPrefab;
    public Transform stationaryCannonBall;

    public float launchForce;
    public float timeBetweenAttacks;
    //public float rotationSpeed;
    private float timeSinceLastShot;
 //   private float firingAngleThreshold = 5f;

    //private bool rotateBack;



    private void Update()
    {
        // Increment how much time has passed since the last shot was fired
        timeSinceLastShot += Time.deltaTime;
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
         //   Vector3 targetPosition = new Vector3(other.transform.position.x, cannon.transform.position.y, other.transform.position.z);
         //   Quaternion targetRotation = Quaternion.LookRotation(targetPosition - cannon.transform.position);

        //    targetRotation *= Quaternion.Euler(0, 180, 0);

            // Gradually rotate towards the player
         //   cannon.transform.rotation = Quaternion.RotateTowards(cannon.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


         //   float angle = Quaternion.Angle(cannon.transform.rotation, targetRotation);

         //   // Fire if within angle threshold
         //   if (angle < firingAngleThreshold && timeSinceLastShot >= timeBetweenAttacks)
         //   {
                FireCannon();
                timeSinceLastShot = 0f;
         //   }
        }
    }



  //  private void OnTriggerExit(Collider other)
  //  {
  //      if (other.tag == "Player")
  //      {
  //          rotateBack = true;
  //      }
  //  }



   // void LateUpdate()
   // {
   //     if (rotateBack)
   //     {
   //         Quaternion forward = Quaternion.Euler(0, 180, 0);
   //         if (Quaternion.Angle(cannon.transform.localRotation, forward) > 0.1f)
   //         {
   //             cannon.transform.localRotation = Quaternion.RotateTowards(cannon.transform.localRotation, forward, rotationSpeed * Time.deltaTime);
   //         }
   //         else
   //         {
   //             rotateBack = false;
   //         }
   //     }
   // }



    private void FireCannon()
    {
        // Instantiate the cannonball at the stationary ball's position
        GameObject newCannonBall = Instantiate(cannonBallPrefab, stationaryCannonBall.position, Quaternion.identity);

        // Get the Rigidbody component and apply force
        Rigidbody rb = newCannonBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(cannon.transform.forward * launchForce); // Note the negative sign, since we rotated the cannon 180 degrees
        }

        Destroy(newCannonBall, 1f);
    }
}
