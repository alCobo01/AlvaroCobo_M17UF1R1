using UnityEngine;

public interface IAudioPlayer
{
    void Play(AudioClip clip);
    void Stop();
    void SetVolume(float volume);
}
