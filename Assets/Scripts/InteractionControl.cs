using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class InteractionControl : MonoBehaviour
{
    public Tilemap tilemap;
    public TMP_Text candyCounterText;
    public TMP_Text scoreCounterText;

    private HashSet<Vector3Int> interactedTiles = new HashSet<Vector3Int>();

    void Update()
    {
        // Get the cell position of the player in the tilemap
        Vector3Int playerCellPosition = tilemap.WorldToCell(transform.position);

        // Check if there is a tile at the player's position and it hasn't been interacted with yet
        if (tilemap.GetTile(playerCellPosition) != null && !interactedTiles.Contains(playerCellPosition))
        {

            // Increment the counter if it's more than 0
            int candyCounter = int.Parse(candyCounterText.text);
            if (candyCounter > 0)
            {
                // Increment the score counter and update the UI
                int currentScore = int.Parse(scoreCounterText.text);
                currentScore++;
                scoreCounterText.text = currentScore.ToString();

                // Decrease the candy counter by 1
                candyCounter--;
                candyCounterText.text = candyCounter.ToString();
            }
        }
    }
}

