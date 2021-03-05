using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Settings",fileName = "WeaponData")]
public class WeaponSettings : ScriptableObject
{
    [SerializeField] private float fireForce;
    [SerializeField] private float fireRefreshRate;
    [SerializeField] private string projectileType;
    [SerializeField] private int projectileDamage;

    public float FireForce => fireForce;

    public float FireRefreshRate => fireRefreshRate;

    public string ProjectileType => projectileType;

    public int ProjectileDamage => projectileDamage;
}
