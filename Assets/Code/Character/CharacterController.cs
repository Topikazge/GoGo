using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterDataConfig _playerDataConfig;
    [SerializeField] private CharacterData _playerData;
    private InputContainer _inputContainer;

    private int _layerEnemy;

    private Vector2 _moveInput;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _inputContainer = FindFirstObjectByType<InputContainer>();
        _rigidBody = GetComponent<Rigidbody2D>();

        _layerEnemy = LayerMask.NameToLayer("Enemy");
        _playerData.CurrentHealt = _playerDataConfig.Healt;
        _playerData.Speed = _playerDataConfig.Speed;

    }

    private void Update()
    {
        _moveInput = _inputContainer.InputActions.Gameplay.Movement.ReadValue<Vector2>();
        CheckDamage();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidBody.linearVelocity = _moveInput * _playerData.Speed;
    }

    private void CheckDamage()
    {
       Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, _playerDataConfig.RadiosApplyDamage, _layerEnemy);

    }
}
