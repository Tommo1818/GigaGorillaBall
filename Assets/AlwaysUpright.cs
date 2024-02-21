using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysUpright : MonoBehaviour
{
    public Transform ballTransform; // Reference to the ball's Transform
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Align the player sprite's Y rotation with the world's up direction
        transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);

        // Position the player sprite relative to the ball's center
        Vector3 offset = transform.localPosition;
        offset.y = 0.0f; // Adjust as needed to position the sprite appropriately
        transform.localPosition = ballTransform.position + offset;
    }
}
