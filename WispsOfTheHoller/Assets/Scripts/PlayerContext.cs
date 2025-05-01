using UnityEngine;

public class PlayerContext : CharacterContext
{
    [SerializeField]
    private GameObject parentObject;
    public GameObject ParentObject { get =>  parentObject; }
    [SerializeField]
    private PlayerController controller;
    public PlayerController Controller { get => controller; }
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
    [SerializeField]
    private AudioSource audioSource;
    public AudioSource AudioSource { get => audioSource; }

}
