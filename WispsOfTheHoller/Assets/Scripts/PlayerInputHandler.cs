using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 Movement { get; private set; }
    public Vector2 Look { get; private set; }
    public bool Attack { get; set; }
    public bool Dash { get; set; }
    public bool Interact { get; set; }

    [ContextMenu("Lock Cursor")]
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    [ContextMenu("Unlock Cursor")]
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Awake()
    {
        LockCursor();
    }

    private void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

    private void OnLook(InputValue value)
    {
        Look = value.Get<Vector2>();
    }

    private void OnAttack(InputValue value)
    {
        Attack = value.isPressed;
    }

    private void OnSprint(InputValue value) 
    { 
        Dash = value.isPressed; 
    }

    private void OnInteract(InputValue value)
    {
        Interact = value.isPressed;
    }
}
