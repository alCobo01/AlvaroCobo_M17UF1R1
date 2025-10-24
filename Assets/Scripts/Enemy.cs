using UnityEngine;

public class Enemy : Character
{
    private void Start()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
        _changeGravityBh = GetComponent<ChangeGravityBehaviour>();
        _moveBehaviour.MoveCharacter(new Vector2(1, 0), 5f);
    }

    private void Update()
    {
        
    }
}