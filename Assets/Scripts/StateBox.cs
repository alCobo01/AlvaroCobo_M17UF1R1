using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateBox : MonoBehaviour
{
    private AnimationBehaviour _animationBehaviour;

    private void Awake()
    {
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }

    private void OnDisable()
    {
        _animationBehaviour.SetBool("HasDialogueEnded", true);
    }
}
