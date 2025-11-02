using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    private Vector2 _direction = new Vector2(1, 0);

    [SerializeField] private float patrolPointA;
    [SerializeField] private float patrolPointB;

    [SerializeField] private float minChangeGravityCooldown = 1.5f;
    [SerializeField] private float maxChangeGravityCooldown = 4f;

    private Coroutine _changeGravityCoroutine;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _changeGravityBh = GetComponent<ChangeGravityBehaviour>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();
        _audioService = AudioManager.Instance;
    }

    private void Start()
    {
        _changeGravityCoroutine = StartCoroutine(ChangeGravityLoop());
    }

    private void Update()
    {
        bool isGrounded = _moveBehaviour.IsGrounded();
        float horizontalSpeed = Mathf.Abs(_direction.x);

        _animationBehaviour.SetGrounded(isGrounded);
        _animationBehaviour.SetSpeed(horizontalSpeed);

        CheckPatrol();
        _moveBehaviour.MoveCharacter(_direction);
    }

    public void StopEnemyBehaviours()
    {
        if (_changeGravityCoroutine != null)
        {
            StopCoroutine(_changeGravityCoroutine);
            _changeGravityCoroutine = null;
        }
    }

    private void CheckPatrol()
    {
        if (_direction.x > 0 && transform.position.x >= patrolPointB)
        {
            _direction.x = -1;
        }
        else if (_direction.x < 0 && transform.position.x <= patrolPointA)
        {
            _direction.x = 1;
        }
    }

    //Control methods to avoid coroutines running when not needed
    private void OnDisable() => StopEnemyBehaviours();
    private void OnDestroy() => StopEnemyBehaviours();

    //Coroutines for gravity change
    private IEnumerator ChangeGravityLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minChangeGravityCooldown, maxChangeGravityCooldown);
            yield return new WaitForSeconds(waitTime);
            if (_moveBehaviour.IsGrounded())
            {
                _changeGravityBh.ChangeGravity();
                _animationBehaviour.Trigger("Jump");
            }
        }
    }
}