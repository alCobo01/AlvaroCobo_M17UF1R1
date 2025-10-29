using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveBehaviour))]
public class ChangeGravityBehaviour : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    private bool _isGravityInverted = false;
    [SerializeField] private float rotationDuration = 5f;

    private void Awake()
    {         
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }

    public void ChangeGravity()
    {
        var gravityScale = _moveBehaviour.GetComponent<Rigidbody2D>().gravityScale;
        _moveBehaviour.SetGravityScale(gravityScale * -1);
        
        _isGravityInverted = !_isGravityInverted;

        StartCoroutine(RotateCharacter());
    }

    private IEnumerator RotateCharacter()
    {
        float elapsedTime = 0f;
        float targetRotation = _isGravityInverted ? 180f : 0f;
        float startingRotation = transform.rotation.eulerAngles.z;

        while (elapsedTime > rotationDuration)
        {
            float currentRotation = Mathf.Lerp(startingRotation, targetRotation, elapsedTime / rotationDuration);
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
    }
}
