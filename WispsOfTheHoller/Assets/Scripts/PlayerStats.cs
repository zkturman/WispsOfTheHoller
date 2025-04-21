using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float Speed { get => speed; }
    [SerializeField]
    private float rotationSpeed;
    public float RotationSpeed { get => rotationSpeed; }
}
