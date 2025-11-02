public interface IAudioService
{
    void PlaySFX(string soundName);
    void PlayMusic(string musicName);
    void PauseMusic();
    void ResumeMusic();
}
