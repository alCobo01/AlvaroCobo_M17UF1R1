using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 1.5f;
    [SerializeField] private float velocityMultiplier = 8f;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    public void MoveCharacter(Vector2 direction)
    {
        float newVelocityX = direction.normalized.x * velocityMultiplier;
        float currentVelocityY = _rb.linearVelocity.y;

        _rb.linearVelocity = new Vector2(newVelocityX, currentVelocityY);
    }

    public void SetGravityScale(float gravityScale) => _rb.gravityScale = gravityScale;

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }
}
