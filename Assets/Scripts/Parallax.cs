using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _startposX, _offsetY, _lenght;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        _startposX = transform.position.x;
        _offsetY = transform.position.y - gameCamera.transform.position.y;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        // Logic for parallax effect on X
        float temp = gameCamera.transform.position.x * (1 - parallaxEffect);
        float distanceX = gameCamera.transform.position.x * parallaxEffect;

        // Keep Y position fixed relative to camera
        float fixedY = gameCamera.transform.position.y + _offsetY;

        transform.position = new Vector3(_startposX + distanceX, fixedY, transform.position.z);

        // Infinite background scroll
        if (temp > _startposX + _lenght) _startposX += _lenght;
        else if (temp < _startposX - _lenght) _startposX -= _lenght;
    }
}
