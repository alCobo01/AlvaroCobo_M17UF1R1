using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;
    private MoveBehaviour _moveBehaviour;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }

    private void Update()
    {
        _animator.SetBool("IsGrounded", _moveBehaviour.IsGrounded());
    }

    public void RunAnimation(string animation)
    {
        _animator.SetTrigger(animation);
    }

}
