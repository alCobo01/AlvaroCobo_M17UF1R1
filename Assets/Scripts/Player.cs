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


    private void FixedUpdate()
    {
        _moveBehaviour.MoveCharacter(_moveInput, 8f);

        if (_moveInput.x != 0)
        {
            _animationBehaviour.RunAnimation("Run");
        }
        else
        {
            _animationBehaviour.RunAnimation("Idle");
        }
    }

    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        Debug.Log(_moveBehaviour.IsGrounded());
        if (_moveBehaviour.IsGrounded())
        {
            _changeGravityBh.ChangeGravity();
            _animationBehaviour.RunAnimation("Jump");
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