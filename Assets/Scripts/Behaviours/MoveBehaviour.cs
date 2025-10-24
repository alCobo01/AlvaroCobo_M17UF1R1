using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 direction, float speed)
    {
        _rb.linearVelocity = direction.normalized * speed;
    }

    public void AddForce(Vector2 force)
    {
        _rb.AddForce(force);
    }

    public void AddForce(Vector2 force, ForceMode2D forceMode)
    {
        _rb.AddForce(force, forceMode);
    }

    public Vector2 GetPosition() => _rb.position;
}
