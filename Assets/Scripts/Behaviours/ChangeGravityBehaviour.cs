using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public class ChangeGravityBehaviour : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    [SerializeField] private float jumpForce;

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }

    public void Jump()
    {
        _moveBehaviour.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}