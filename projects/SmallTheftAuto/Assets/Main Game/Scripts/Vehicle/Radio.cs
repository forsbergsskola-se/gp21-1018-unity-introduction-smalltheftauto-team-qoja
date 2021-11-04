using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Radio : MonoBehaviour
{
    [SerializeField] public AudioClip audioClip1;
    [SerializeField] public AudioClip audioClip2;
    [SerializeField] public AudioClip audioClip3;
    [SerializeField] private AudioClip audioClip4;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        ToggleRadio(false);
    }

    public void Update()
    {
        MusicPicker();
        VolumeControl();
    }

    private void OnDisable()
    {
        RadioManager(null, 1f);
        ToggleRadio(false);
    }

    void RadioManager(AudioClip audioClip, float pitch)
    {
        audioSource.enabled = false;
        audioSource.clip = audioClip;
        audioSource.pitch = pitch;
        audioSource.enabled = true;
    }

    void MusicPicker()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RadioManager(null, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
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
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            RadioManager(audioClip4,1f);
        }
        
    }
    void VolumeControl()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus))
        {
            audioSource.volume += 0.05f;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
        {
            audioSource.volume -= 0.05f;
        }
    }

    public void ToggleRadio(bool toggle)
    {
        this.enabled = toggle;
    }
}
