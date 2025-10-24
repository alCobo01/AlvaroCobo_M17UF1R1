using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RunAnimation(Vector2 direction)
    {
        if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        _animator.SetFloat("Velocity", direction.magnitude);
    }

}
