using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathHandler : MonoBehaviour
{
    public UnityEvent OnPlayerDied;
    private bool _isAlive = true;

    public void Die()
    {
        if (!_isAlive) return;
        _isAlive = false;
        OnPlayerDied?.Invoke();
    }
}
