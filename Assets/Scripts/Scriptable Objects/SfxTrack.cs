using UnityEngine;

[CreateAssetMenu(fileName = "SfxTrack", menuName = "Scriptable Objects/SfxTrack")]
public class SfxTrack : ScriptableObject
{
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1.0f;

    [Range(0.1f, 3f)]
    public float pitch = 1.0f;
}
