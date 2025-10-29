using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class Player : Character, IPlayerActions
{
    private InputSystem_Actions inputActions;
    private Vector2 _moveInput;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _changeGravityBh = GetComponent<ChangeGravityBehaviour>();
        _animationBehaviour = GetComponent<AnimationBehaviour>();

        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }

    void Start() => inputActions.Enable();

    void OnEnable() => inputActions.Enable();

    void OnDisable() => inputActions.Disable();


    private void Update()
    {
        bool isGrounded = _moveBehaviour.IsGrounded();
        float verticalSpeed = _moveBehaviour.GetVerticalSpeed();
        float horizontalSpeed = Mathf.Abs(_moveInput.x * 8f);

        _animationBehaviour.SetGrounded(isGrounded);
        _animationBehaviour.SetSpeed(horizontalSpeed);
        _animationBehaviour.SetVerticalSpeed(verticalSpeed);
    }

    private void FixedUpdate()
    {
        _moveBehaviour.MoveCharacter(_moveInput, 8f);
    }

    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (_moveBehaviour.IsGrounded())
        {
            _changeGravityBh.ChangeGravity();
            _animationBehaviour.TriggerJump();
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
}