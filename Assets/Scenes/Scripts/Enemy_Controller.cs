using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{

    [SerializeField] private Cooldown cooldown;

    public Transform goal;

    public float shootRange = 6f;
    public float meleeRange = 2f;
    public float rotationSpeed = 200f;
    public float launchForce;
    public float firing_Angle;

    public NavMeshAgent navAgent;
    public GameObject cannon;
    public GameObject cannonBallPrefab;
    public Transform stationaryCannonBall;

    private float initialNavSpeed;


    void Start()
    {
        initialNavSpeed = navAgent.speed;
    }


    void Update()
    {
        
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        MoveTowards(goal);
        FireCannon();
        float distance = Vector3.Distance(transform.position, goal.position);

        if (distance <= meleeRange)
        {
            navAgent.speed = 0f;
            RotateTowards(goal);
        }
        else
        {
            navAgent.speed = initialNavSpeed;
        }
     
    }

    private void MoveTowards(Transform goal)
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
    }

    void FireCannon()
    {
        if (cooldown.IsCoolingDown) return;

        float distance = Vector3.Distance(transform.position, goal.position);

        if (distance <= shootRange)

        {

                    // Instantiate the cannonball at the stationary ball's position
                    GameObject newCannonBall = Instantiate(cannonBallPrefab, stationaryCannonBall.position, Quaternion.identity);

                    // Get the Rigidbody component and apply force
                    Rigidbody rb = newCannonBall.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddForce(cannon.transform.forward * launchForce); // Note the negative sign, since we rotated the cannon 180 degrees
                    }

        }
        Debug.Log("Cooldown Reset!");
        cooldown.StartCoolDown();
        //}
    }
    
    //Rotates enemy toward player even when movement is stopped
    private void RotateTowards(Transform goal)
    {
        Vector3 targetPosition = new Vector3(goal.transform.position.x, transform.position.y, goal.transform.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
