using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 Movement { get; private set; }
    public Vector2 Look { get; private set; }
    public bool Attack { get; private set; }
    public bool Dash { get; private set; }
    public bool Interact { get; private set; }

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
        Attack = value.Get<bool>();
    }

    private void OnSprint(InputValue value) 
    { 
        Dash = value.Get<bool>(); 
    }

    private void OnInteract(InputValue value)
    {
        Interact = value.Get<bool>();
    }
}
