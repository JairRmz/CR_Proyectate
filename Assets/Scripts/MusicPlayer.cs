using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> songs;  // List to store multiple audio clips
    public AudioSource bocina;

    // Start is called before the first frame update
    void Start()
    {
        // Check if there are any songs in the list
        if (songs.Count > 0)
        {
            // Select a random song from the list
            int randomSongIndex = Random.Range(0, songs.Count);
            bocina.clip = songs[randomSongIndex];
            bocina.loop = true;
            bocina.Play();
        }
        else
        {
            Debug.LogWarning("No songs added to the list!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the current song has finished playing
        if (!bocina.isPlaying)
        {
            // Select a new random song from the list
            int randomSongIndex = Random.Range(0, songs.Count);
            bocina.clip = songs[randomSongIndex];
            bocina.Play();
        }
    }
}
