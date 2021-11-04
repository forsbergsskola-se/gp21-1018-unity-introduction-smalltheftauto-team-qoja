using UnityEngine;

public class Cat : MonoBehaviour
{
    public float purringDistance;
    public AudioClip[] audioClips;
    private AudioSource[] _audioSources;
    private Player _player;
    private float _distanceToPlayer;

    private bool _hasMeowed;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _audioSources = GetComponentsInChildren<AudioSource>();

       for (var i = 0; i < _audioSources.Length; i++)
       {
          _audioSources[i].clip = audioClips[i]; 
       }
    }
    
    private void Update()
    {
        _distanceToPlayer = Vector2.Distance(this.transform.position, _player.transform.position);
        
        if (_distanceToPlayer <= purringDistance)
        {
            Purr();
        }
        else StopPurr();
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

    private void MeowWithCooldown()
    {
        Invoke(nameof(Meow), 1f);
    }

    private void Purr()
    {
        _audioSources[1].enabled = true;
    }

    private void StopPurr()
    {
        _audioSources[1].enabled = false;
    }
}
