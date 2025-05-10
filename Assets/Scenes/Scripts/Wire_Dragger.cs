using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wire_Dragger : MonoBehaviour, IDragHandler
{
    [SerializeField] private float dampingSpeed = .05f;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
