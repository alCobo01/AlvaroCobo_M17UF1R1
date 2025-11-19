using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageCollider : MonoBehaviour
{
   [SerializeField] private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void EnableCollider() => _collider.enabled = true;
    public void DisableCollider() => _collider.enabled = false;
}
