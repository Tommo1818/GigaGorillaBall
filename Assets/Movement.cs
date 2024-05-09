using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    public LayerMask groundLayers; // Assign the layers considered as ground in the inspector
    public float extraHeightText = 0.1f;
    public bool hasJumpItem = false;
    private AlwaysUpright alwaysUpright;
    public CircleCollider2D circleCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alwaysUpright = GetComponentInChildren<AlwaysUpright>();
        // If you didn't assign the circle collider in the inspector, find it automatically
        if (circleCollider == null)
        {
            circleCollider = GetComponent<CircleCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouchingGround() && Input.GetKeyDown(KeyCode.Space) && hasJumpItem)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, groundLayers);

            if (hit.collider != null)
            {
                Vector2 jumpDirection = hit.normal;
                
                rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reset the level
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    bool IsTouchingGround()
    {
        /*
        Vector2 boxCastSize = new Vector2(transform.localScale.x, extraHeightText);
        Vector2 boxCastOrigin = (Vector2)transform.position - new Vector2(0, transform.localScale.y / 2);

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, extraHeightText, groundLayers);
        return raycastHit.collider != null;
        */
        float radius = circleCollider.radius + extraHeightText;
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, groundLayers);

        return hit != null;
    }

    public void PickUpJumpItem()
    {
        hasJumpItem = true;
        Debug.Log("hasJumpItem was set to true");
    }
}
