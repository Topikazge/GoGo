using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [SerializeField] private float _speed;
    [SerializeField] private int _currentHealt;

    public float Speed { get => _speed; set => _speed = value; }
    public int CurrentHealt { get => _currentHealt; set => _currentHealt = value; }
}

