using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startpos;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
    }

    void FixedUpdate()
    {
        float distance = gameCamera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
