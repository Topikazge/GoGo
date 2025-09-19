using UnityEngine;
using UnityEngine.InputSystem;

public class InputContainer : MonoBehaviour
{
    private InputPlayer _inputActions;

    public InputPlayer InputActions
    {
        get { return _inputActions; }
    }

    private void Awake()
    {
        _inputActions = new InputPlayer();
        _inputActions.Enable();
    }
}
