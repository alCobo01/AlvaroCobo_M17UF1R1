using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetGrounded(bool isGrounded)
    {
        _animator.SetBool("IsGrounded", isGrounded);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    public void SetVerticalSpeed(float verticalSpeed)
    {
        _animator.SetFloat("VerticalSpeed", verticalSpeed);
    }

    public void TriggerJump()
    {
        _animator.SetTrigger("Jump");
    }

}
