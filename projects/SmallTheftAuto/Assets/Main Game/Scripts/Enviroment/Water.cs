using UnityEngine;

public class Water : MonoBehaviour
{
    private AudioSource audioFile;
    void Start()
    {
        audioFile = gameObject.GetComponent<AudioSource>();
        audioFile.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        audioFile.enabled = false;
        audioFile.enabled = true;
        audioFile.loop = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        audioFile.loop = false;
        audioFile.enabled = false;
    }
}
