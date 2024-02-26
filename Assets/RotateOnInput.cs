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
    public float maxRotationAngle = 10f;

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
        } else
        {
            ResetRotation();
        }
    }
    public void ResetRotation()
    {
        // Determine the angle between the current rotation and the initial rotation
        float angle = Quaternion.Angle(transform.rotation, initialRotation);

        if (angle > 0.1f) // Adjust the threshold as needed
        {
            // Determine the direction of rotation
            Vector3 rotationAxis = Vector3.Cross(transform.up, initialRotation * Vector3.up);

            // Rotate the platform back to the initial rotation
            transform.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);
        }
        else 
        {
            // If the angle is less than the threshold, reset the rotation to the initial rotation
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
