using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked_Door : MonoBehaviour
{

    public Vector3 endPos;
    public Vector3 startPos;
    public float speed = 1.0f;

    private bool moving = false;
    private bool opening = true;
 //   private bool closing = false;
 //   private Vector3 startPos;
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
}