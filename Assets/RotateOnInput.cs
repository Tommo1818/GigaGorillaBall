using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevelGameObject : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public Transform pivotPoint;
    private Quaternion initialRotation;
    public float maxRotationAngle;
    public float rotationThreshold;

    void Start()
    {
        initialRotation = transform.rotation;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            ResetRotation();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateClockwise();

            float angle = Quaternion.Angle(transform.rotation, initialRotation);
            if (angle > maxRotationAngle)
            {
                // Determine the direction of rotation
                Vector3 rotationAxis = Vector3.Cross(transform.up, initialRotation * Vector3.up);

                // Rotate the platform back to the initial rotation
                transform.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateAntiClockwise();
            // Limit the rotation
            float angle = Quaternion.Angle(transform.rotation, initialRotation);
            if (angle > maxRotationAngle)
            {
                // Determine the direction of rotation
                Vector3 rotationAxis = Vector3.Cross(transform.up, initialRotation * Vector3.up);

                // Rotate the platform back to the initial rotation
                transform.RotateAround(pivotPoint.position, rotationAxis, rotationSpeed * Time.deltaTime);
            }
        }
        else // if no keys are pressed, reset rotation
        {
            ResetRotation();
        }
    }
    public void ResetRotation()
    {
        // Determine the angle between the current rotation and the initial rotation
        float angle = Quaternion.Angle(transform.rotation, initialRotation);

        if (angle > rotationThreshold)
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
