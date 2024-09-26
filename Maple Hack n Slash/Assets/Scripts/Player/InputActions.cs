using UnityEngine;

public class Input : MonoBehaviour
{
    private InputSystem_Actions _input;

    public Vector2 MoveDirection;
    public bool attack;
    public bool secondaryAction;

    private void Update()
    {
        MoveDirection = _input.Player.Move.ReadValue<Vector2>();
        attack = _input.Player.Attack.WasPressedThisFrame();
        secondaryAction = _input.Player.Attack.WasPressedThisFrame();
    }

    private void Awake() { _input = new InputSystem_Actions(); }
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}
