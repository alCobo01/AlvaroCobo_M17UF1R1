using UnityEngine;

[RequireComponent(typeof(AnimationBehaviour))]
public class StateBox : MonoBehaviour
{
    private AnimationBehaviour _animationBehaviour;

    private void Awake() => _animationBehaviour = GetComponent<AnimationBehaviour>();
    private void OnDisable() => _animationBehaviour.SetBool("HasDialogueEnded", true);
}
