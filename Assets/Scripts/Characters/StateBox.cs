using UnityEngine;

[RequireComponent(typeof(AnimationBehaviour))]
public class StateBox : MonoBehaviour
{
    private AnimationBehaviour _animationBehaviour;

    private void Awake() => _animationBehaviour = GetComponent<AnimationBehaviour>();
    
    public void Show()
    {
        gameObject.SetActive(true);
        _animationBehaviour.SetBool("HasDialogueEnded", false);
    }

    public void Hide() => _animationBehaviour.SetBool("HasDialogueEnded", true);
    public void Deactivate() => gameObject.SetActive(false);
}
