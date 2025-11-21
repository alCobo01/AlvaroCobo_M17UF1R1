using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Vector2 direction = Vector2.right;

    private void Awake()
    {
        bulletPool = GetComponent<ObjectPool>();
    }

    public void Fire()
    {
        var bullet = bulletPool.Pop();
        bullet.transform.position = shootPoint.transform.position;
        
        var velocity = new Vector2(direction.x * bulletSpeed, direction.y * bulletSpeed);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = velocity;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetOwnerPool(bulletPool);
    }
}
