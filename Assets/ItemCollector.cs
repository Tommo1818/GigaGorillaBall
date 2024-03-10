using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int bananaCount = 0;
    private int melonCount = 0;

    [SerializeField] private TextMeshProUGUI bananaCountText;
    [SerializeField] private Movement playerMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            bananaCount++;
            bananaCountText.text = "Bananas: " + bananaCount;
        }

        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            melonCount++;
            playerMovement.PickUpJumpItem();
        }
    }
}
