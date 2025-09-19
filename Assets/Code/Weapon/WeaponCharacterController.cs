using UnityEngine;
using System.Collections.Generic;

public class WeaponCharacterController : MonoBehaviour
{

    [SerializeField] private int _maxWeapon;
    private List<WeaponBase> _waepons;
    public void AddWeapon(WeaponBase weapon)
    {

    }

    public void UpdateWeapon()
    {

    }
    private void Update()
    {
        foreach (WeaponBase waepons in _waepons)
        {
            waepons.Update();
        }
    }
}
