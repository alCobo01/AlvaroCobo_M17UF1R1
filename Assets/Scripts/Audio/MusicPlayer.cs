using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour, IAudioPlayer
{
    private AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true;
    }

    public void Play(AudioClip clip)
    {
        if (musicSource.clip == clip && musicSource.isPlaying) return;

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void Stop()
    {
        musicSource?.Stop();
    }
}