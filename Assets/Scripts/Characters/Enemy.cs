using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    private Vector2 _direction = new Vector2(1, 0);

    [SerializeField] private float minMoveCooldown = 1f;
    [SerializeField] private float maxMoveCooldown = 3f;

    [SerializeField] private float minChangeGravityCooldown = 1.5f;
    [SerializeField] private float maxChangeGravityCooldown = 4f;

    private Coroutine _moveCoroutine;
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
        _moveBehaviour.MoveCharacter(_direction);
        StartEnemyBehaviours();
    }

    private void Update()
    {
        bool isGrounded = _moveBehaviour.IsGrounded();
        float horizontalSpeed = Mathf.Abs(_direction.x);

        _animationBehaviour.SetGrounded(isGrounded);
        _animationBehaviour.SetSpeed(horizontalSpeed);
    }

    public void StartEnemyBehaviours()
    {
        _moveCoroutine = StartCoroutine(MoveLoop());
        _changeGravityCoroutine = StartCoroutine(ChangeGravityLoop());
    }

    public void StopEnemyBehaviours()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
        if (_changeGravityCoroutine != null)
        {
            StopCoroutine(_changeGravityCoroutine);
            _changeGravityCoroutine = null;
        }
    }

    //Control methods to avoid coroutines running when not needed
    private void OnDisable() => StopEnemyBehaviours();
    private void OnDestroy() => StopEnemyBehaviours();

    //Coroutines for movement and gravity change
    private IEnumerator MoveLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minMoveCooldown, maxMoveCooldown);
            yield return new WaitForSeconds(waitTime);

            _direction.x *= -1;
            _moveBehaviour.MoveCharacter(_direction);
        }
    }

    private IEnumerator ChangeGravityLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minChangeGravityCooldown, maxChangeGravityCooldown);
            yield return new WaitForSeconds(waitTime);
            if (_moveBehaviour.IsGrounded())
            {
                _changeGravityBh.ChangeGravity();
                _animationBehaviour.TriggerJump();
            }
        }
    }
}