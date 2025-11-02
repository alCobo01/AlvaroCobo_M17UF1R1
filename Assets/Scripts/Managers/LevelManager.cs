using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private MusicTrack musicTrack;
    [SerializeField] private SfxTrack gameOverTrack;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private float gameOverDelay = 1.5f;

    private IAudioService _audioService;

    private void Start()
    {
        _audioService = AudioManager.Instance;
        _audioService.PlayMusic(musicTrack.name);

        player.OnPlayerDied.AddListener(() => StartCoroutine(GameOver()));
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        Time.timeScale = 0f;
        _audioService.PauseMusic();
        _audioService.PlaySFX(gameOverTrack.name);
        gameOverScreen.SetActive(true);
    }
}
