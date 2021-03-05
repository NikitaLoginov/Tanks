using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponSettings weaponSettings;
    [SerializeField] private Transform firePointTransform;
    [SerializeField] private Transform targetPointTransform;
    private ITankInput _tankInput;
    private TankWeapon _tankWeapon;

    private void Awake()
    {
        _tankInput = new PlayerInput();
        _tankWeapon = new TankWeapon(weaponSettings, firePointTransform ,targetPointTransform);
    }

    private void OnEnable()
    {
        EventBroker.FireWeaponHandler += Fire;
    }

    private void Update()
    {
        _tankInput.ReadInput();
    }

    private void Fire()
    {
        _tankWeapon.Fire();
    }

    private void OnDisable()
    {
        EventBroker.FireWeaponHandler -= Fire;
    }
}
