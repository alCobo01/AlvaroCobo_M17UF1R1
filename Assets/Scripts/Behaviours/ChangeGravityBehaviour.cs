using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public class ChangeGravityBehaviour : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    private Rigidbody2D _rigidbody2D;
    private bool _isGravityInverted = false;

    private void Awake()
    {         
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ChangeGravity()
    {
        var gravityScale = _rigidbody2D.gravityScale;
        _moveBehaviour.SetGravityScale(gravityScale * -1);
        
        _isGravityInverted = !_isGravityInverted;

        transform.rotation = Quaternion.Euler(0f, 0f, _isGravityInverted ? 180f : 0f);
    }
}
