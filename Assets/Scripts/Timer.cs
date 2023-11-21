using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text time;
    public int scene;
    private float contadorTiempo = 120; // Non-static variable

    // Start is called before the first frame update
    void Start()
    {
        contadorTiempo = 120; // Initialize contadorTiempo to zero when the scene starts
    }

    // Update is called once per frame
    void Update()
    {
        contadorTiempo -= Time.deltaTime;

        // Check if time has run out
        if (contadorTiempo <= 0)
        {
            // Time has run out, load the specified scene
            SceneManager.LoadScene(scene);
        }
        else
        {
            // Calculate minutes and seconds
            int minutes = Mathf.FloorToInt(contadorTiempo / 60);
            int seconds = Mathf.FloorToInt(contadorTiempo % 60);

            // Display the time in "mm:ss" format
            string tiempo_s = string.Format("{0:00}:{1:00}", minutes, seconds);

            time.text = tiempo_s;
        }
    }
}