using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class InstantDeathTrigger : MonoBehaviour, IDeathTrigger
{
    public void ActivateDeathTrigger(PlayerDeathHandler player) => player.Die();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerDeathHandler>(out var player))
        {
            ActivateDeathTrigger(player);
        }
    }
}
