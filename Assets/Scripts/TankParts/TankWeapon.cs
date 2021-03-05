using UnityEngine;

public class TankWeapon 
{
    private readonly WeaponSettings _weaponSetting;
    private readonly Transform _firePointTransform;
    private readonly Transform _targetTransform;
    private float _nextFireTime;

    public TankWeapon(WeaponSettings weaponSettings,Transform firePointTransform,Transform targetTransform)
    {
        _weaponSetting = weaponSettings;
        _firePointTransform = firePointTransform;
        _targetTransform = targetTransform;
    }

    public void Fire()
    {
        if (!CanFire()) return;
        _nextFireTime = Time.time + _weaponSetting.FireRefreshRate;
        SpawnProjectile(_firePointTransform);
    }

    private bool CanFire()
    {
        return Time.time >= _nextFireTime;
    }

    private void SpawnProjectile(Transform firePoint)
    {
        GameObject spawnedProjectile;
        if(_weaponSetting.ProjectileType == "Small")
            spawnedProjectile = ObjectPooler.Instance.GetPooledSmallProjectile();
        else
            spawnedProjectile = ObjectPooler.Instance.GetPooledMediumProjectile();

        if (spawnedProjectile != null)
        {
            //Position
            spawnedProjectile.SetActive(true);
            spawnedProjectile.transform.position = firePoint.position;

            //Rotation
            Vector2 shootDir = _targetTransform.position - _firePointTransform.position;
            float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg - 90f; //offset 90 degrees
            var projectileRB = spawnedProjectile.GetComponent<Rigidbody2D>();
            projectileRB.rotation = angle;
            
            //Launch 
            projectileRB.AddForce(shootDir * _weaponSetting.FireForce, ForceMode2D.Impulse);
        }

    }
}
