using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using Vector3 = UnityEngine.Vector3;

public class PoweredWireBehaviour : MonoBehaviour
 {
    bool Dragging = false;

      void Start()
      {

      }

      void Update()
      {
        if(Dragging)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 convertedMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            convertedMousePos.z = 0;
            transform.position = convertedMousePos;
        }
      }

      private void OnMouseDown()
      {
        Dragging = true;
      }

      private void OnMouseUp()
      {
        Dragging = false;
      }
 }
