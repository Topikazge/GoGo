using UnityEngine;

/// <summary>
/// Данные для разделения врагов (избежание столкновений)
/// </summary>
[System.Serializable]
public class EnemySeparationData
{
    [Header("Separation Settings")]
    [SerializeField] private float _separationRadius = 1f;
    [SerializeField] private float _separationForce = 5f;

    // Properties
    public float Radius => _separationRadius;
    public float Force => _separationForce;
}
