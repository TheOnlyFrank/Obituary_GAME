using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Navigation : MonoBehaviour
{

    public Transform goal;

    public float shootRange = 4f;
    public float meleeRange = 1.5f;
    public float rotationSpeed = 100f;

    public NavMeshAgent navAgent;
    private float initialNavSpeed;


    void Start()
    {
        initialNavSpeed = navAgent.speed;
    }


    void Update()
    {
        //Transform goal = null;


        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        MoveTowards(goal);
        float distance = Vector3.Distance(transform.position, goal.position);

        if (distance <= meleeRange)
        {
            navAgent.speed = 0f;
            float angle = 5;
            if (Vector3.Angle(transform.forward, goal.transform.position - transform.position) >= angle)
            {
                RotateTowards(goal);
            }
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

   //Rotates enemy toward player even when movement is stopped
   private void RotateTowards(Transform goal)
   {
       transform.LookAt(goal.transform);
       Vector3 direction = (goal.position - transform.position);
       Quaternion lookRotation = Quaternion.LookRotation(direction);
       transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }


    
}