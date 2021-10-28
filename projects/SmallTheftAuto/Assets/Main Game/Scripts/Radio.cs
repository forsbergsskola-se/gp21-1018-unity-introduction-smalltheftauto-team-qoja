using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Radio : MonoBehaviour
{
    
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Update()
    {
       // if (audioSource.enabled)
       // {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                RadioManager(null, 1f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RadioManager(audioClip1,0.8f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                RadioManager(audioClip2, 0.8f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                RadioManager(audioClip3,1f);
            }

            if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus))
            {
                audioSource.volume += 0.1f;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
            {
                audioSource.volume -= 0.1f;
            } 
                
     //   }
        

    }

       void RadioManager(AudioClip audioClip, float pitch)
    {
        audioSource.enabled = false;
        audioSource.clip = audioClip;
        audioSource.pitch = pitch;
        audioSource.enabled = true;
    }
}
