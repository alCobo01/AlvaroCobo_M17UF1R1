using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FrontPalmTree : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if ((playerMask & (1 << collision.gameObject.layer)) != 0)   
        {
            Vector2 normalizedImpact = collision.GetContact(0).normal;    
            if (normalizedImpact.y < 0)
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }
    }
}
