using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    private IPooleable _ownerPool;

    public void SetOwnerPool(IPooleable pool) => _ownerPool = pool;

    private void ReturnToPool()
    {
        if (_ownerPool != null)
            _ownerPool.Push(gameObject);   
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReturnToPool();
    }
}
