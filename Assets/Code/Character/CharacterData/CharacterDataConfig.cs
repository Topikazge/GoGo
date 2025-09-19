using UnityEngine;

[CreateAssetMenu(fileName = "Character Config", menuName = "Configs/Character")]
public class CharacterDataConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _healt;
    [SerializeField] private float _radiosApplyDamage;
    [SerializeField] private GameObject _prefub;

    public float Speed => _speed;
    public int Healt => _healt;
    public float RadiosApplyDamage => _radiosApplyDamage;
    public GameObject Prefub => _prefub;
}
