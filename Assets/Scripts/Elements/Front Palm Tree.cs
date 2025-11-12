using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FrontPalmTree : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision Detected with {collision.gameObject.name}, GM layer {gameObject.layer}, playermask {playerMask.value}");    
        if (collision.gameObject.layer == playerMask)   
        {
            Vector2 normalizedImpact = collision.GetContact(0).normal;
            Debug.Log(normalizedImpact);    

            if (normalizedImpact.y < 0)
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }
}
