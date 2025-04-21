using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    [SerializeField]
    private GameObject parentObject;
    public GameObject ParentObject { get =>  parentObject; }
    [SerializeField]
    private GameObject model;
    public GameObject Model { get => model; }
    [SerializeField]
    private Rigidbody body;
    public Rigidbody Body { get => body; }
    [SerializeField]
    private PlayerStats stats;
    public PlayerStats Stats { get => stats; }
    [SerializeField]
    private GameObject cameraRoot;
    public GameObject CameraRoot { get => cameraRoot; }
    [SerializeField]
    private PlayerInputHandler inputHandler;
    public PlayerInputHandler InputHandler { get => inputHandler; }
}
