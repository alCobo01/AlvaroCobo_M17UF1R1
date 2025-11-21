using UnityEngine;

public interface IPauseService
{
    bool IsPaused { get; }
    void TogglePause();
    void PauseGame();
    void ResumeGame();
}
