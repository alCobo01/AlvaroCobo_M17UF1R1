using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private ObjectPool bulletPool;

    private void Awake()
    {
        bulletPool = GetComponent<ObjectPool>();
    }

    public void Fire()
    {
        var bullet = bulletPool.Pop();
        bullet.transform.position = shootPoint.transform.position;
        
        var velocity = new Vector2(1 * bulletSpeed, 0);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = velocity;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetOwnerPool(bulletPool);
    }
}
