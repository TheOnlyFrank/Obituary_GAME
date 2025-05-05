using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using Vector3 = UnityEngine.Vector3;

public class PoweredWireBehaviour : MonoBehaviour
 {
      private bool mouseDown = false;
      public PoweredWireStats powerWireS;
     // Start is called before the first frame update
      void Start()
      {
          powerWireS = gameObject.GetComponent<PoweredWireStats>();
      }

      //Update is called once per frame
      void Update()
      {
          MoveWire();
      }

      void OnMouseDown() 
      {
          mouseDown = true; 
      }

      void OnMouseOver()
      {
          powerWireS.movable = true;
      }

      void OnMouseExit()
      {
          if(!powerWireS.moving)
              powerWireS.movable = false;
      }

      void OnMouseUp()
      {
          mouseDown = false;
      }

      void MoveWire()
      {
          if(mouseDown && powerWireS.movable)
          {
              powerWireS.moving = true;
              float mouseX = Input.mousePosition.x;
              float mouseY = Input.mousePosition.y;

              gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, transform.position.z));
          }
          else
          {
              powerWireS.moving = false;
          }
     }
 }
