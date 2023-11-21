using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class CandyControl : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the UI Text element
    public Tilemap tilemap; // Reference to the Tilemap containing your tileset
    public int maxCount = 5; // Maximum counter value

    private int currentCount = 0;
    private float timer = 0f;
    private float incrementInterval = 1f; // Increment the counter every 1 second

    public AudioSource speaker;
    public AudioClip soundEffect;


    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the timer has reached the increment interval
        if (timer >= incrementInterval)
        {
            // Reset the timer
            timer = 0f;

            // Get the cell position of the player in the tilemap
            Vector3Int playerCellPosition = tilemap.WorldToCell(transform.position);

            // Check if there is a tile at the player's position
            if (tilemap.GetTile(playerCellPosition) != null)
            {
                // Increment the counter if it's less than the max value
                if (currentCount < maxCount)
                {
                    currentCount++;
                    speaker.PlayOneShot(soundEffect);
                    UpdateCounterUI();
                }
            }
        }
    }
    void UpdateCounterUI()
    {
        // Update the UI Text with the current counter value
        counterText.text = currentCount.ToString();
    }

}
