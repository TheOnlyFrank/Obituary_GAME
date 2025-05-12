using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wire_Dragger : MonoBehaviour, IDragHandler
{
    [SerializeField] private float dampingSpeed = .05f;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    LineRenderer line;

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position, globalMousePosition, ref velocity, dampingSpeed);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponentInParent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(3, new Vector3(gameObject.transform.localPosition.x - .1f, gameObject.transform.localPosition.y - .1f, 0));
        line.SetPosition(2, new Vector3(gameObject.transform.localPosition.x - .4f, gameObject.transform.localPosition.y - .1f, 0));
    }

   // void OnCollisionEnter2D(Collision2D collision)
   // {
   //     if (collision.gameObject.tag == gameObject.tag)
   //     {
   //         Debug.Log("Tag match!!!!");
   //         transform.position = collision.gameObject.transform.position;
   //     }
   //     else
   //     {
   //         Debug.Log("No match detected");
   //     }
   // }
}
