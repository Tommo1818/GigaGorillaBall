using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysUpright : MonoBehaviour
{
    private float orientationAngle = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Align the player sprite's Y rotation with the world's up direction
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, orientationAngle);

        // Position the player sprite relative to the ball's center
        Vector3 offset = transform.localPosition;
        offset.y = 0.0f; // Adjust as needed to position the sprite appropriately
    }

    public void FlipOrientationAngle()
    {
        orientationAngle += 180.0f;
        if (orientationAngle >= 360.0f)
        {
            orientationAngle -= 360.0f;
        }   
    }
}
