using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private MusicTrack musicTrack;
    private IAudioService _audioService;

    private void Start()
    {
        _audioService = AudioManager.Instance;
        _audioService.PlayMusic(musicTrack.name);
    }
}
