using System;
using UnityEngine;

/// <summary>
/// Базовый класс для всех видов оружия
/// </summary>
[Serializable]
public abstract class WeaponBase
{
    /// <summary>
    /// Обновление логики оружия
    /// </summary>
    public abstract void Update();
    
    /// <summary>
    /// Активация оружия
    /// </summary>
    public virtual void Activate() { }
    
    /// <summary>
    /// Деактивация оружия
    /// </summary>
    public virtual void Deactivate() { }
}
