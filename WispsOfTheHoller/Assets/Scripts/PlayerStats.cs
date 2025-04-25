using UnityEditor.UIElements;
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
    [SerializeField]
    private float baseMana = 100;
    public float BaseMana { get => baseMana; }
    [SerializeField]
    private float dashRequiredMana = 8;
    public float DashRequiredMana { get => dashRequiredMana; }
    [SerializeField]
    private float screamRequiredMana = 13;
    public float ScreamRequiredMana { get => screamRequiredMana; }
}
