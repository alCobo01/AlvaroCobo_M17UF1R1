using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class Player : Character, IPlayerActions
{
    private InputSystem_Actions inputActions;

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

    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        _changeGravityBh.Jump();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var inputVector = new Vector2(context.ReadValue<Vector2>().x, 0f);
            _moveBehaviour.MoveCharacter(inputVector, 10f);
        }
        else if (context.canceled)
        {
            _moveBehaviour.MoveCharacter(Vector2.zero, 0f);
        }
    }
}