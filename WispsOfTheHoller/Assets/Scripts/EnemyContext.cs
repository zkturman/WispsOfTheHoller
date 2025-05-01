using UnityEngine;

public class EnemyContext : CharacterContext
{
    [SerializeField]
    private GameObject _parent;
    public GameObject Parent { get => _parent; }
    [SerializeField]
    private EnemyController _controller;
    public EnemyController Controller { get =>  _controller; }
    [SerializeField]
    private Rigidbody _body;
    public Rigidbody Body { get => _body; }
    [SerializeField]
    private GameObject _model;
    public GameObject Model { get => _model; }
    [SerializeField]
    private Animator _animator;
    public Animator Animator { get => _animator; }
    [SerializeField]
    private EnemyStats _stats;
    public EnemyStats Stats { get => _stats; }
    [SerializeField]
    private GameObject _followObject;
    public GameObject FollowObject { get => _followObject; }
    [SerializeField]
    private CollectionTimer _timer;
    public CollectionTimer Timer { get => _timer; }
    [SerializeField]
    private AudioSource _audioSource;
    public AudioSource AudioSource { get => _audioSource; }

    private void Awake()
    {
        if (_followObject == null)
        {
            _followObject = GameObject.FindWithTag("Player");
        }
        if (_timer == null)
        {
            _timer = FindFirstObjectByType<CollectionTimer>();
        }
    }
}
