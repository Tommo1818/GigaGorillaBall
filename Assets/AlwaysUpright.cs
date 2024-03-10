using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysUpright : MonoBehaviour
{
    private bool isGravityFlipped = false;
    private Vector3 previousPosition;
    private float rotationY = 0.0f; // Moved outside of Update()

    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionOfMovement = transform.position - previousPosition;
        
        if (directionOfMovement.x < 0)
        {
            // Player is moving left
            rotationY = 180.0f;
        }
        else if (directionOfMovement.x > 0)
        {
            // Player is moving right
            rotationY = 0.0f;
        }

        // If gravity is flipped, rotate the player 180 degrees around the x-axis
        float rotationX = isGravityFlipped ? 180.0f : 0.0f;

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);

        previousPosition = transform.position;

        /*
        // Align the player sprite's Y rotation with the world's up direction
        transform.rotation = Quaternion.Euler(0.0f, orientationAngle, orientationAngle);

        // Position the player sprite relative to the ball's center
        Vector3 offset = transform.localPosition;
        offset.y = 0.0f; // Adjust as needed to position the sprite appropriately
        */
    }

    public void FlipGravity()
    {
        isGravityFlipped = !isGravityFlipped;
        Physics2D.gravity = new Vector2(0, isGravityFlipped ? 9.81f : -9.81f);
    }
}
