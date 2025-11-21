using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Chest : AnimatedWorldElement, IInteractable
{
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
