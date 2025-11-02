using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour, IAudioService
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private List<SfxTrack> sfxList;
    [SerializeField] private List<MusicTrack> musicList;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    private Dictionary<string, SfxTrack> sfxDictionary;
    private Dictionary<string, MusicTrack> musicDictionary;

    private void Awake()
    {
        Instance = this;

        sfxSource.playOnAwake = false;
        musicSource.playOnAwake = false;

        sfxDictionary = new Dictionary<string, SfxTrack>();
        foreach (var sfx in sfxList)
        {
            sfxDictionary[sfx.name] = sfx;
        }

        musicDictionary = new Dictionary<string, MusicTrack>();
        foreach (var music in musicList)
        {
            musicDictionary[music.name] = music;
        }
    }

    public void PlaySFX(string soundName)
    {
        if (sfxSource == null) return;
        if (sfxDictionary.TryGetValue(soundName, out SfxTrack sfxTrack))
        {
            sfxSource.clip = sfxTrack.clip;
            sfxSource.volume = sfxTrack.volume;
            sfxSource.pitch = sfxTrack.pitch;
            sfxSource.PlayOneShot(sfxTrack.clip);
        }
    }

    public void PlayMusic(string musicName)
    {
        if (musicSource == null) return;

        if (musicDictionary.TryGetValue(musicName, out MusicTrack musicTrack))
        {
            if (musicSource.clip == musicTrack && musicSource.isPlaying) return;

            musicSource.clip = musicTrack.clip;
            musicSource.volume = musicTrack.volume;
            musicSource.pitch = musicTrack.pitch;
            musicSource.loop = musicTrack.loop;
            musicSource.Play();
        }
    }

    public void PauseMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
    }

    public void ResumeMusic()
    {
        if (musicSource.clip != null && !musicSource.isPlaying)
            musicSource.UnPause();
    }
}
