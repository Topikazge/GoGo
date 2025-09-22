using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Контейнер для управления системой ввода
/// </summary>
public class InputContainer : MonoBehaviour
{
    [Header("Input System")]
    private InputPlayer _inputActions;

    /// <summary>
    /// Получить экземпляр системы ввода
    /// </summary>
    public InputPlayer InputActions => _inputActions;

    private void Awake()
    {
        InitializeInputSystem();
    }

    /// <summary>
    /// Инициализация системы ввода
    /// </summary>
    private void InitializeInputSystem()
    {
        _inputActions = new InputPlayer();
        
        if (_inputActions == null)
        {
            Debug.LogError("Failed to create InputPlayer instance!");
        }
    }

    private void OnEnable()
    {
        _inputActions?.Enable();
    }
    
    private void OnDisable()
    {
        _inputActions?.Disable();
    }
}
