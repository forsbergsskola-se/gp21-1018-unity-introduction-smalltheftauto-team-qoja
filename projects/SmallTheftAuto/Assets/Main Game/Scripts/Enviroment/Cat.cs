using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public float purringDistance;
    public AudioClip[] _audioClips;
    
    private AudioSource[] _audioSources;
    
    private Player _player;
    private float _distance;

    private bool _hasMeowed ;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _audioSources = GetComponentsInChildren<AudioSource>();

       for (var i = 0; i < _audioSources.Length; i++)
       {
          _audioSources[i].clip = _audioClips[i]; 
       }
       
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (_hasMeowed == false)
        {
            _hasMeowed = true;
            MeowWithCooldown();
        }
    }

    public void Meow()
    {
        _audioSources[0].enabled = false;
        _audioSources[0].enabled = true;
        _hasMeowed = false;
    }
    
    public void MeowWithCooldown()
    {
        Invoke("Meow", 1f);
    }
    
    public void Purr()
    {
        _audioSources[1].enabled = true;
    }

    public void StopPurr()
    {
        _audioSources[1].enabled = false;
    }
    
    void Update()
    {
        _distance = Vector2.Distance(this.transform.position, _player.transform.position);
        if (_distance <= purringDistance)
        {
            Purr();
        }
        else StopPurr();
    }
}
