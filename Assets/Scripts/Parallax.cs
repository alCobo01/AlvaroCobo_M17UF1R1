using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        //float temp = (gameCamera.transform.position.x * (1 - parallaxEffect));
        float distance = gameCamera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        //if (temp > startpos + length) startpos += length;
        //else if (temp < startpos - length) startpos -= length;
    }
}
