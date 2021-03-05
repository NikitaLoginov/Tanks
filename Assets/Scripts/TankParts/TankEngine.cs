using UnityEngine;

public class TankEngine
{
    private readonly ITankInput _tankInput;
    private readonly Rigidbody2D _rigidbody2DToMove;
    private readonly Transform _transformToMove;
    private readonly TankSettings _tankSettings;
    private Vector2 _movement;

    public TankEngine(ITankInput tankInput,Transform transformToMove, Rigidbody2D rigidbody2DToMove, TankSettings tankSettings)
    {
        _tankInput = tankInput;
        _transformToMove = transformToMove;
        _rigidbody2DToMove = rigidbody2DToMove;
        _tankSettings = tankSettings;
    }

    public void Tick()
    {
        Move();
        Turn();
    }
    private void Move()
    {
        float thrust = _tankInput.Movement;
        _movement = _transformToMove.up * (thrust * _tankSettings.MoveSpeed * Time.fixedDeltaTime);
        _rigidbody2DToMove.MovePosition(_rigidbody2DToMove.position + _movement);
    }

    private void Turn()
    {
        float rotation = _tankInput.Rotation;
        float turn = rotation * _tankSettings.TurnSpeed * Time.fixedDeltaTime;
        _rigidbody2DToMove.MoveRotation(_rigidbody2DToMove.rotation - turn);
    }
}
