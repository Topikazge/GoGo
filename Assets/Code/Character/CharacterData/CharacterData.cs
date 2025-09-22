using System;
using UnityEngine;

/// <summary>
/// Данные персонажа во время выполнения
/// </summary>
[Serializable]
public class CharacterData
{
    [Header("Current Stats")]
    [SerializeField] private float _speed;
    [SerializeField] private int _currentHealth;

    // Properties
    public float Speed { get => _speed; set => _speed = value; }
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
}

