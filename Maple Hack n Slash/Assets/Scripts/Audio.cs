using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    // Source for Audio and Music
    private AudioSource _audioSource;
    public AudioClip _clip1;
    
    private void Start()
    {
        // Get AudioSource Component
        _audioSource = GetComponent<AudioSource>();
        // Set AudioSource Clip
        _audioSource.clip = _clip1;
        // Play Music
        _audioSource.Play();
    }
}