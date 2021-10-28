using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IHurtOnCrash
{
    public int DamageOnCrash => 2;
    // Start is called before the first frame update
    private AudioSource audioFile;
    void Start()
    {
        audioFile = gameObject.GetComponent<AudioSource>();
        audioFile.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        audioFile.enabled = false;
        audioFile.enabled = true;
        audioFile.loop = true;
        Debug.Log("I am colliding");
        Destructible destructible = other.gameObject.GetComponentInParent<Destructible>();
        if (destructible != null)
        {
            destructible.TakeDamage(DamageOnCrash); 
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //AudioSource audioFile = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        audioFile.loop = false;
        audioFile.enabled = false;
    }
}
