using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    private int _index;

    private void Awake()
    {
        EventBroker.SwitchWeaponsUpHandler += SwitchWeaponsUp;
        EventBroker.SwitchWeaponsDownHandler += SwitchWeaponsDown;
    }

    private void SwitchWeaponsUp()
    {
        if(weapons[_index].activeInHierarchy)
            weapons[_index].gameObject.SetActive(false);
        
        _index++;
        if (_index >= weapons.Length)
            _index = 0;
        weapons[_index].gameObject.SetActive(true);
    }

    private void SwitchWeaponsDown()
    {
        if(weapons[_index].activeInHierarchy)
            weapons[_index].gameObject.SetActive(false);
        
        _index--;
        if (_index < 0)
            _index = weapons.Length - 1;
        weapons[_index].gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventBroker.SwitchWeaponsUpHandler -= SwitchWeaponsUp;
        EventBroker.SwitchWeaponsDownHandler -= SwitchWeaponsDown;
    }
}
