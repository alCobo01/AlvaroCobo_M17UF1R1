using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AnimationBehaviour))]
public class Chest : MonoBehaviour, IInteractable
{
    private AnimationBehaviour _animationBehaviour;

    private void Awake()
    {
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }

    public void Interact()
    {
        _animationBehaviour.Trigger("Open");
        LevelManager.Instance.WinGame();
    }
}
