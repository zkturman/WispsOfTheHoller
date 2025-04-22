using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float Speed { get => speed; }
    [SerializeField]
    private float rotationSpeed;
    public float RotationSpeed { get => rotationSpeed; }
    [SerializeField]
    private float dashSpeed = 10;
    public float DashSpeed { get => dashSpeed; }
}
