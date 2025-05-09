using UnityEngine;
using UnityEngine.EventSystems;



public class PoweredWireBehaviour : MonoBehaviour, IDragHandler
 {

  [SerializeField] private float dampingSpeed = 0.5f;
  private RectTransform draggingObjectRectTransform;
  private Vector3 velocity = Vector3.zero;
  

  private void Awake() 
    {
      draggingObjectRectTransform = transform as RectTransform;
    }

  public void OnDrag(PointerEventData eventData)
    {
      if(RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
          draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position, globalMousePosition, ref velocity, dampingSpeed);
        }
    }



 }
