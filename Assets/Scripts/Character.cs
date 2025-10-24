using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(ChangeGravityBehaviour))]
[RequireComponent(typeof(AnimationBehaviour))]
public class Character : MonoBehaviour
{
    protected MoveBehaviour _moveBehaviour;
    protected ChangeGravityBehaviour _changeGravityBh;
    protected AnimationBehaviour _animationBehaviour;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _changeGravityBh = GetComponent<ChangeGravityBehaviour>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }
}