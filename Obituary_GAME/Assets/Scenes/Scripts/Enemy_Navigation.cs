using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Navigation : MonoBehaviour
{

    public Transform goal;
    public float meleeRange = 1.5f;
    public float rotationSpeed = 10f;

    
    void Update()
    {
     //   Transform goal = null;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        MoveTowards(goal); 
        
         //Rotates enemy toward player if within Nav Mesh Agent's stopping distance, so that enemies don't get stuck
         //near the player but looking the wrong way, always turning toward player rather than stopping entirely
     //   if (IsInMeleeRangeOf(goal))
     //   {
     //       RotateTowards(goal);
     //   }
       
    }

    //private bool IsInMeleeRangeOf(Transform goal)
    //{
    //    float distance = Vector3.Distance(transform.position, goal.position);
    //    if (distance <= meleeRange)
    //    {
    //        return (goal);
    //    }
    //}

    private void MoveTowards(Transform goal)
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>(); 
        agent.SetDestination(goal.position);
    }

        //Rotates enemy toward player even when movement is stopped
    //private void RotateTowards(Transform goal)
    //{
    //    transform.LookAt(goal.transform);
    //    Vector3 direction = (goal.position - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(direction);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    //}


}