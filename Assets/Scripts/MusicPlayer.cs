using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource bocina;
    public AudioClip musica;
    // Start is called before the first frame update
    void Start()
    {
        bocina.clip = musica;
        bocina.loop = true;
        bocina.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
