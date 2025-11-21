using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InstantDeathTrigger : MonoBehaviour, IDeathTrigger
{
    public void ActivateDeathTrigger(Player player) => player.Die();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            ActivateDeathTrigger(player);
        }
    }
}
