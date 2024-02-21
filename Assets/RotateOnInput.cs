using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevelGameObject : MonoBehaviour
{
    public float rotationSpeed; // Adjust this value for desired rotation speed
    public Transform pivotPoint; // The object around which to rotate
    public float smoothingSpeed;
    private float currentRotationLerpValue;
    public Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateClockwise(); // Call function for clockwise rotation
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateAntiClockwise(); // Call function for anticlockwise rotation
        } 
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ResetRotation();
        }
        
    }
    void ResetRotation()
    {
        if (Quaternion.Angle(transform.rotation, initialRotation) > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, currentRotationLerpValue);
            currentRotationLerpValue += smoothingSpeed * Time.deltaTime;
        }
        else
        {
            currentRotationLerpValue = 0;
        }
    }
    private void RotateClockwise()
    {
        transform.RotateAround(pivotPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void RotateAntiClockwise()
    {
        transform.RotateAround(pivotPoint.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
