using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;

    private Rigidbody2D _rb;
    private Cannon _ownerPool;
    private float _currentLifeTime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetOwnerPool(Cannon ownerPool)
    {
        _ownerPool = ownerPool;
    }

    private void OnEnable() => _currentLifeTime = 0f;

    private void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= lifetime)
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        if (_ownerPool != null)
        {
            _ownerPool.Push(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
