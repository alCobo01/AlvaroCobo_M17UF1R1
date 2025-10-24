using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public class ChangeGravityBehaviour : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    private bool _isGravityInverted = false;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }

    public void ChangeGravity()
    {
        var gravityScale = _moveBehaviour.GetComponent<Rigidbody2D>().gravityScale;
        _moveBehaviour.SetGravityScale(gravityScale * -1);
        
        _isGravityInverted = !_isGravityInverted;

        if (_isGravityInverted)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
