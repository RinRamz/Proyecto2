using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private PlayerInputManager _inputManager;

    private void Awake()
    {
        _inputManager = new PlayerInputManager();
    }

    private void OnEnable()
    {
        _inputManager.Enable();
    }

    private void OnDisable()
    {
        _inputManager.Disable();
    }

    public Vector2 GetMovement()
    {
        return _inputManager.PlayerController.Movement.ReadValue<Vector2>();
    }

    public bool IsAttackPressed()
    {
        return _inputManager.PlayerController.Attack.triggered;
    }

    public bool IsAttackHold()
    {
        return _inputManager.PlayerController.HoldAttack.triggered;
    }

    public bool IsJumpPressed()
    {
        return _inputManager.PlayerController.Jump.triggered;
    }

    public bool IsJumpHold()
    {
        return _inputManager.PlayerController.HoldJump.triggered;
    }
}
