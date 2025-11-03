using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private Player player;

    [SerializeField] private MusicTrack musicTrack;
    [SerializeField] private SfxTrack gameOverTrack;
    [SerializeField] private SfxTrack gameWinnedTrack;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private float gameOverDelay = 1.5f;
    [SerializeField] private float gameWinnedDelay = 1f;

    private IAudioService _audioService;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

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

    public void WinGame()
    {
        StartCoroutine(HandleGameWinned());
    }

    private IEnumerator HandleGameWinned()
    {
        yield return new WaitForSeconds(gameWinnedDelay);
        Time.timeScale = 0f;
        _audioService.PauseMusic();
        _audioService.PlaySFX(gameWinnedTrack.name);
        gameOverScreen.SetActive(true);
    }
}
