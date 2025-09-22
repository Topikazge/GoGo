using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Контроллер оружия персонажа
/// </summary>
public class WeaponCharacterController : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private int _maxWeapons = 3;
    
    [Header("Weapon Management")]
    private List<WeaponBase> _weapons;
    private int _currentWeaponIndex = 0;
    
    private void Awake()
    {
        InitializeWeaponSystem();
    }
    
    /// <summary>
    /// Инициализация системы оружия
    /// </summary>
    private void InitializeWeaponSystem()
    {
        _weapons = new List<WeaponBase>();
    }
    
    /// <summary>
    /// Добавление оружия в арсенал
    /// </summary>
    /// <param name="weapon">Оружие для добавления</param>
    public void AddWeapon(WeaponBase weapon)
    {
        if (weapon == null)
        {
            Debug.LogWarning("Trying to add null weapon!");
            return;
        }
        
        if (_weapons.Count >= _maxWeapons)
        {
            Debug.LogWarning("Maximum weapons limit reached!");
            return;
        }
        
        _weapons.Add(weapon);
        weapon.Activate();
        
        Debug.Log($"Weapon added. Total weapons: {_weapons.Count}");
    }
    
    /// <summary>
    /// Удаление оружия из арсенала
    /// </summary>
    /// <param name="weapon">Оружие для удаления</param>
    public void RemoveWeapon(WeaponBase weapon)
    {
        if (_weapons.Contains(weapon))
        {
            weapon.Deactivate();
            _weapons.Remove(weapon);
            
            // Корректируем индекс текущего оружия
            if (_currentWeaponIndex >= _weapons.Count)
            {
                _currentWeaponIndex = Mathf.Max(0, _weapons.Count - 1);
            }
        }
    }
    
    /// <summary>
    /// Переключение на следующее оружие
    /// </summary>
    public void SwitchToNextWeapon()
    {
        if (_weapons.Count <= 1) return;
        
        _currentWeaponIndex = (_currentWeaponIndex + 1) % _weapons.Count;
        Debug.Log($"Switched to weapon {_currentWeaponIndex}");
    }
    
    /// <summary>
    /// Переключение на предыдущее оружие
    /// </summary>
    public void SwitchToPreviousWeapon()
    {
        if (_weapons.Count <= 1) return;
        
        _currentWeaponIndex = (_currentWeaponIndex - 1 + _weapons.Count) % _weapons.Count;
        Debug.Log($"Switched to weapon {_currentWeaponIndex}");
    }
    
    /// <summary>
    /// Обновление всех оружий
    /// </summary>
    public void UpdateWeapons()
    {
        foreach (WeaponBase weapon in _weapons)
        {
            if (weapon != null)
            {
                weapon.Update();
            }
        }
    }
    
    private void Update()
    {
        UpdateWeapons();
        HandleWeaponSwitching();
    }
    
    /// <summary>
    /// Обработка переключения оружия
    /// </summary>
    private void HandleWeaponSwitching()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToPreviousWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextWeapon();
        }
    }
    
    /// <summary>
    /// Получение текущего оружия
    /// </summary>
    /// <returns>Текущее оружие или null</returns>
    public WeaponBase GetCurrentWeapon()
    {
        if (_weapons.Count == 0 || _currentWeaponIndex >= _weapons.Count)
        {
            return null;
        }
        
        return _weapons[_currentWeaponIndex];
    }
    
    /// <summary>
    /// Получение количества оружий
    /// </summary>
    /// <returns>Количество оружий в арсенале</returns>
    public int GetWeaponCount()
    {
        return _weapons.Count;
    }
}
