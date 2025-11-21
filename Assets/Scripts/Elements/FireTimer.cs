using UnityEngine;

public class FireTimer : AnimatedWorldElement
{
    [SerializeField] private float fireRate = 1f;
    private float _fireTimer;

    private void Awake()
    {
        _animationBehaviour = GetComponent<AnimationBehaviour>();
    }

    private void Update()
    {
        if (_fireTimer >= 1f / fireRate)
        {
            _animationBehaviour.Trigger("Fire");
            _fireTimer = 0f;
        }
        _fireTimer += Time.deltaTime;
    }
}
