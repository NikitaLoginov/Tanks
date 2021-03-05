using UnityEngine;

[CreateAssetMenu(menuName = "Tank/Settings", fileName = "TankData")]
public class TankSettings : ScriptableObject
{
    [SerializeField] private float turnSpeed = 180f;
    [SerializeField] private float moveSpeed = 15f;

    public float TurnSpeed => turnSpeed;

    public float MoveSpeed => moveSpeed;
}
