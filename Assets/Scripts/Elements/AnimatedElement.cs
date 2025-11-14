using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AnimationBehaviour))]
public class AnimatedWorldElement : MonoBehaviour
{
    protected AnimationBehaviour _animationBehaviour;

    private void Awake()
    {
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }
}
