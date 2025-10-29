using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private IAudioPlayer musicPlayer;
    private IAudioPlayer sfxPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            musicPlayer = GetComponentInChildren<MusicPlayer>();
            sfxPlayer = GetComponentInChildren<SFXPlayer>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
