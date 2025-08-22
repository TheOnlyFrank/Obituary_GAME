using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Locked_Door : MonoBehaviour, IInteractable
{

    // This script is the master control script for all door types - always unlocked, locked doors requiring a key (specific or otherwise).
    // The below script is to be used as a guide, once finalised it is to be placed into the door prefab and then the other existing door scripts can be removed from the project (as they will no longer be required).
    //Door interaction will be handled by use of an interface triggered method, to standardise the player interactions with game elements.

    public Vector3 endPos;
    public Vector3 startPos;
    public float speed = 1.0f;

    private bool moving = false;
    private bool opening = true;
    public float delay = 0.0f;

    [SerializeField] bool isLocked;

    // Start is called before the first frame update
    //   void Start()
    //   {
    //       startPos = transform.position;
    //   }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (opening)
            {
                moveDoor(endPos);
            }
            else
            {
                moveDoor(startPos);

                // Detection if closing while player in doorway, to re-open door 
                //                if (closing)
            }
        }
    }

    void moveDoor(Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.position, goalPos);
        if (dist > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        else
        {
            if (opening)
            {
                delay += Time.deltaTime;
                if (delay > 5.0f)
                {
                    opening = false;
                    delay = 0.0f;
                }
            }
            else
            {
                moving = false;
                opening = true;
            }
        }
    }

    public bool moving_Out
    {
        get { return moving; }
        set { moving = value; }
    }

    public void OnPlayerInteract(Player_Controls player)
    {
        
    }


}
