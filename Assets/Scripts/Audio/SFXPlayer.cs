using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour, IAudioPlayer
{
    private AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true;
    }

    public void Play(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void Stop()
    {
        
    }
}