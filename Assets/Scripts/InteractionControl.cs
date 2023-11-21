using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractionControl : MonoBehaviour
{
    public Tilemap tilemap;
    public TMP_Text candyCounterText;
    public TMP_Text scoreCounterText;

    public AudioSource speaker;
    public AudioClip soundEffect;
    public int scene;

    // Use a dictionary to keep track of whether a tile has been interacted with
    private Dictionary<Vector3Int, bool> tileInteracted = new Dictionary<Vector3Int, bool>();

    void Update()
    {
        // Get the cell position of the player in the tilemap
        Vector3Int playerCellPosition = tilemap.WorldToCell(transform.position);

        // Check if there is a tile at the player's position and if it hasn't been interacted with
        if (tilemap.GetTile(playerCellPosition) != null && !tileInteracted.ContainsKey(playerCellPosition))
        {
            // Increment the counter if it's less than the max value
            int candyCounter = int.Parse(candyCounterText.text);
            if (candyCounter > 0)
            {
                // Increment the score counter and update the UI
                speaker.PlayOneShot(soundEffect);
                int currentScore = int.Parse(scoreCounterText.text);
                currentScore++;
                scoreCounterText.text = currentScore.ToString();

                // Decrease the candy counter by 1
                candyCounter--;
                candyCounterText.text = candyCounter.ToString();

                // Mark the tile as interacted
                tileInteracted.Add(playerCellPosition, true);

                // Check if all tiles have been interacted with
                if (AllTilesInteracted())
                {
                    // Change the scene (you can replace "NextScene" with the name of your next scene)
                    SceneManager.LoadScene(scene);
                }
            }
        }
    }

    // Helper method to check if all tiles have been interacted with
    private bool AllTilesInteracted()
    {
        // Iterate through all the tiles in the tilemap
        foreach (Vector3Int tilePosition in tilemap.cellBounds.allPositionsWithin)
        {
            // Check if the tile exists and hasn't been interacted with
            if (tilemap.GetTile(tilePosition) != null && !tileInteracted.ContainsKey(tilePosition))
            {
                return false; // There is at least one tile that hasn't been interacted with
            }
        }

        return true; // All tiles have been interacted with
    }
}
