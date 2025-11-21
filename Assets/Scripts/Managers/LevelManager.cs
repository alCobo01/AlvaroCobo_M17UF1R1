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
    [SerializeField] private GameObject gameWonScreen;
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
        _audioService.PauseMusic();
        _audioService.PlaySFX(gameOverTrack.name);
        yield return new WaitForSeconds(gameOverDelay);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        StartCoroutine(HandleGameWon());
    }

    private IEnumerator HandleGameWon()
    {
        _audioService.PauseMusic();
        _audioService.PlaySFX(gameWinnedTrack.name);
        yield return new WaitForSeconds(gameWinnedDelay);
        gameWonScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
