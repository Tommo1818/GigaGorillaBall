using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevelGameObject : MonoBehaviour
{
    public float rotationSpeed; // Adjust this value for desired rotation speed
    public Transform pivotPoint; // The object around which to rotate

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
