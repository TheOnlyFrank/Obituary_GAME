using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar_Puzzle : MonoBehaviour
{
    [SerializeField] private Transform pfSonarPing;

    private Transform sweepTransform;
    private float rotationSpeed;
    private float radarDistance;
    private List<Collider> colliderList;
    //private LayerMask layerMask;

    private void Awake()
    {
        sweepTransform = transform.Find("pivot");
        rotationSpeed = 180f;
        radarDistance = 16f;
        colliderList = new List<Collider>();
        //layerMask = LayerMask.GetMask("Radar");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float previousRotation = (sweepTransform.eulerAngles.z % 360) - 180;
        sweepTransform.eulerAngles -= new Vector3(0,0, rotationSpeed * Time.deltaTime);
        float currentRotation = (sweepTransform.eulerAngles.z % 360) - 180;

        if (previousRotation < 0 && currentRotation >= 0)
        {
            // Half rotation
            colliderList.Clear();
        }

        if (Physics.Raycast(transform.position, GetVectorFromAngle(sweepTransform.eulerAngles.z), out var raycastHit, radarDistance))
        {
            // Hit something
            if (!colliderList.Contains(raycastHit.collider))
            {
                // Hit for first time
                colliderList.Add(raycastHit.collider);

                Instantiate(pfSonarPing, raycastHit.point, Quaternion.identity);
            }
        }

    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        //angle = 0 -> 360
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
