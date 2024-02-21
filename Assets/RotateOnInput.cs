using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnInput : MonoBehaviour
{
    public float rotationSpeed; // Adjust this value for desired tilt speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); // Rotate clockwise
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime); // Rotate counter-clockwise
        }
        
    }
}
