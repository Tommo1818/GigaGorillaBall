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
    public void ResetRotation()
    {
        float angle = Quaternion.Angle(transform.rotation, initialRotation);

        if (angle > 0.1f) // Adjust the threshold as needed
        {
            float step = rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.RotateTowards(transform.rotation, initialRotation, step);

            // Calculate the pivot direction and the pivot position
            Vector3 pivotDirection = transform.position - pivotPoint.position;
            Vector3 pivotPosition = pivotPoint.position + pivotDirection;

            // Rotate the platform around the pivot position
            transform.RotateAround(pivotPosition, Vector3.up, step);
            transform.rotation = targetRotation;
        }
        else
        {
            transform.rotation = initialRotation;
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
