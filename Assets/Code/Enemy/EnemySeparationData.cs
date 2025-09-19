using UnityEngine;

[System.Serializable]
public class EnemySeparationData
{
    [SerializeField] private float separationRadius;
    [SerializeField] private float separationForce;

    public float Radius => separationRadius;
    public float Force => separationForce;
}
