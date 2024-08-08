using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
   

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle the mute state by pressing M
            audioSource.mute = !audioSource.mute;
        }
    }
}
