using UnityEngine;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _input;

    // public Vector2 MoveDirection;
    public float Horizontal;
    public float Vertical;
    public bool Attack;
    public bool SecondaryAction;

    private void Update()
    {
        // MoveDirection = _input.Player.Move.ReadValue<Vector2>();
        Attack = _input.Player.Attack.WasPressedThisFrame();
        SecondaryAction = _input.Player.Attack.WasPressedThisFrame();
        Horizontal = _input.Player.Move.ReadValue<Vector2>().x;
        Vertical = _input.Player.Move.ReadValue<Vector2>().y;
    }

    private void Awake() { _input = new InputSystem_Actions(); }
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}
