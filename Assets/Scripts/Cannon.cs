using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject playerTransform;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float offsetAngle;

    private float _fireTimer;
    private Stack<GameObject> _bulletPool = new Stack<GameObject>();
    private float _angle;
    private Vector2 _directionToPlayer;

    private void Update()
    {
        _directionToPlayer = (playerTransform.transform.position - shootPoint.transform.position).normalized;
        _angle = Mathf.Atan2(_directionToPlayer.y, _directionToPlayer.x) * Mathf.Rad2Deg + offsetAngle;

        transform.rotation = Quaternion.Euler(0f, 0f, _angle);

        if (_fireTimer >= 1f / fireRate)
        {
            Fire();
            _fireTimer = 0f;
        }
        _fireTimer += Time.deltaTime;
    }

    private void Fire()
    {
        GameObject bullet;
        if (_bulletPool.Count > 0)
        {
           bullet = Pop();
        }
        else
        {
            bullet = Instantiate(bulletPrefab);
        }

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetOwnerPool(this);

        bullet.transform.position = shootPoint.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, _angle);
        
        var velocity = new Vector2(_directionToPlayer.x * bulletSpeed, _directionToPlayer.y * bulletSpeed);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = velocity;
    }

    private GameObject Pop()
    {
        GameObject bullet = _bulletPool.Pop();
        bullet.SetActive(true);
        return bullet;
    }

    public void Push(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Push(bullet);
    }
}
