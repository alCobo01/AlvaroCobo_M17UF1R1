using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _startpos, _lenght;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        _startpos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        float distance = gameCamera.transform.position.x * parallaxEffect;
        float temp = gameCamera.transform.position.x * (1 - parallaxEffect);

        if (temp > _startpos + _lenght) _startpos += _lenght;
        else if (temp < _startpos - _lenght) _startpos -= _lenght;

        transform.position = new Vector3(_startpos + distance, transform.position.y, transform.position.z);
    }
}
