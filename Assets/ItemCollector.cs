using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int bananaCount = 0;

    [SerializeField] private TextMeshProUGUI bananaCountText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            bananaCount++;
            bananaCountText.text = "Bananas: " + bananaCount;
        }
    }
}
