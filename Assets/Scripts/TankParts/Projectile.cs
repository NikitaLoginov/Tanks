using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private WeaponSettings weaponSettings;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<Enemy>().TakeDamage(weaponSettings.ProjectileDamage);
        gameObject.SetActive(false);
    }
}
