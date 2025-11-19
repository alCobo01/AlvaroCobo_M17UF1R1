using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : AnimatedWorldElement
{
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private DamageCollider damageCollider;

    private IPooleable _ownerPool;
    private Rigidbody2D _rb;
    private Collider2D _collider;

    private void Awake()
    {
        _animationBehaviour = GetComponent<AnimationBehaviour>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _collider.enabled = true;
        damageCollider.EnableCollider();
    }

    public void SetOwnerPool(IPooleable pool) => _ownerPool = pool;

    public void ReturnToPool()
    {
        if (_ownerPool != null)
            _ownerPool.Push(gameObject);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & collisionLayer) != 0)
        {
            _rb.linearVelocity = Vector2.zero;
            _collider.enabled = false;
            damageCollider.DisableCollider();
            _animationBehaviour.Trigger("Explode");
        }
    }
}
