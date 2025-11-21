using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class PauseManager : MonoBehaviour, IPauseService, IUIActions
{
    public static PauseManager Instance { get; private set; }

    [SerializeField] private GameObject pauseMenuUI;
    private InputSystem_Actions _inputActions;
    private IAudioService _audioService;

    public bool IsPaused { get; private set; } = false;

    private void Awake()
    {
        Instance = this;
        _inputActions = new InputSystem_Actions();
        _inputActions.UI.SetCallbacks(this);
    }

    private void Start()
    {
        _inputActions.Enable();

        _audioService = AudioManager.Instance;
        Time.timeScale = 1f;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);
    }

    void OnEnable() => _inputActions.Enable();

    void OnDisable() => _inputActions.Disable();

    public void TogglePause()
    {
        if (IsPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        if (IsPaused) return;
        Time.timeScale = 0f;
        IsPaused = true;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        _audioService.PauseMusic();
    }

    public void ResumeGame()
    {
        if (!IsPaused) return;
        Time.timeScale = 1f;
        IsPaused = false;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        _audioService.ResumeMusic();
    }

    public void OnPause(InputAction.CallbackContext context)
    { 
        if (context.performed)
            TogglePause();
    }
}
