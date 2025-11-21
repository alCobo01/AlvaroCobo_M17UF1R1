using UnityEngine;

public class FallLimiter : MonoBehaviour
{
    [SerializeField] private float maxPositiveSpeed = 10f;
    [SerializeField] private float maxNegativeSpeed = -10f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = _rigidbody2D.linearVelocity;
        float limitedVelocity = currentVelocity.y;

        if (currentVelocity.y < maxNegativeSpeed) limitedVelocity = maxNegativeSpeed;
        if (currentVelocity.y > maxPositiveSpeed) limitedVelocity = maxPositiveSpeed;

        _rigidbody2D.linearVelocity = new Vector2(currentVelocity.x, limitedVelocity);
    }
}
