using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlayerDeathHandler playerDeathHandler;

    [SerializeField] private MusicTrack musicTrack;
    private IAudioService _audioService;

    private void Start()
    {
        _audioService = AudioManager.Instance;
        _audioService.PlayMusic(musicTrack.name);

        playerDeathHandler.OnPlayerDied.AddListener(HandlePlayerDied);
    }

    private void HandlePlayerDied()
    {
        //Activar pantalla game over y sfx de muerte
        //_audioService.PauseMusic();
        Debug.Log("Player Died - Game Over");
    }

}
