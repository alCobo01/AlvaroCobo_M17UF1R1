using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class Player : Character, IPlayerActions
{
    public UnityEvent OnPlayerDied;

    [SerializeField] private GameObject _stateBox;
    [SerializeField] private SfxTrack jumpSfx;

    private InputSystem_Actions _inputActions;
    private Vector2 _moveInput;
    private IInteractable _currentInteractable;
    private bool _canChangeGravity = true;
    private bool _isAlive = true;   

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _changeGravityBh = GetComponent<ChangeGravityBehaviour>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();

        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);

        _audioService = AudioManager.Instance;
    }

    void Start() => _inputActions.Enable();

    void OnEnable() => _inputActions.Enable();

    void OnDisable() => _inputActions.Disable();


    private void Update()
    {
        bool isGrounded = _moveBehaviour.IsGrounded();
        float horizontalSpeed = Mathf.Abs(_moveInput.x);

        _animationBehaviour.SetGrounded(isGrounded);
        _animationBehaviour.SetSpeed(horizontalSpeed);
    }

    private void FixedUpdate()
    {
        _moveBehaviour.MoveCharacter(_moveInput);
    }

    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (_moveBehaviour.IsGrounded() && _canChangeGravity)
        {
            _changeGravityBh.ChangeGravity();
            _animationBehaviour.Trigger("Jump");
            _audioService.PlaySFX(jumpSfx.name);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveInput = new Vector2(context.ReadValue<Vector2>().x, 0f);
        }
        else if (context.canceled)
        {
            _moveInput = Vector2.zero;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _currentInteractable != null)
        {
            _currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            _canChangeGravity = false;
            _currentInteractable = interactable;
            _stateBox.SetActive(true);
        }  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            if (_currentInteractable == interactable)
            {
                _canChangeGravity = true;
                _currentInteractable = null;
                _stateBox.SetActive(false);
            } 
        }
    }

    public void Die()
    {
        if (!_isAlive) return;
        _isAlive = false;
        _animationBehaviour.Trigger("Death");
        OnPlayerDied?.Invoke();
    }

}