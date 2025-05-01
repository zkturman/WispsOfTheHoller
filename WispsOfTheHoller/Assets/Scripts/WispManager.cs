using System.Collections.Generic;
using UnityEngine;

public class WispManager : MonoBehaviour
{
    private static WispManager _instance;
    [SerializeField]
    private GameObject[] _wispLocations;
    private Dictionary<Vector3, int> _wispMap;
    [SerializeField]
    private GameObject _wispPrefab;
    private WispBehaviour[] _wispInstances;
    private Queue<Vector3> _collectedWisps;
    [SerializeField]
    private int _wispsToLoseOnReset = 5;
    [SerializeField]
    private AudioClip _collectionSound;
    [SerializeField]
    private AudioSource _soundEmitter;
    private CollectionTimer _gameTimer;
    private MonsterSpawner _monsterSpawner;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        _collectedWisps = new Queue<Vector3>();
        _wispMap = new Dictionary<Vector3, int>();
        _wispInstances = new WispBehaviour[_wispLocations.Length];
        for (int i = 0; i < _wispLocations.Length; i++)
        {
            _wispMap.Add(_wispLocations[i].transform.position, i);
        }
        InitialiseWisps();
        DontDestroyOnLoad(this.gameObject);
    }

    public void InitialiseWisps()
    {
        _gameTimer = GetComponent<CollectionTimer>();
        for (int i = 0; i < _wispLocations.Length; i++)
        {
            GameObject wispInstance = Instantiate(_wispPrefab, _wispLocations[i].transform.position, Quaternion.identity);
            WispBehaviour instanceBehaviour = wispInstance.GetComponent<WispBehaviour>();
            instanceBehaviour.Initialise(this);
            _instance._wispInstances[i] = instanceBehaviour;
        }
    }

    public void MarkCollected(WispBehaviour collectedWisp)
    {
        if (_monsterSpawner == null)
        {
            _monsterSpawner = FindFirstObjectByType<MonsterSpawner>();
        }
        _monsterSpawner.RespawnMonster();
        _collectedWisps.Enqueue(collectedWisp.transform.position);
        _gameTimer.ResetTimer();
        if (_collectedWisps.Count == _wispLocations.Length)
        {
            LevelManager.FinishGame();
        }
        else if (_collectionSound != null)
        {
            _soundEmitter.PlayOneShot(_collectionSound);
        }
    }

    public bool CanReset()
    {
        return _collectedWisps.Count >= _wispsToLoseOnReset;
    }

    public void ResetCollection()
    {
        InitialiseWisps();
        int wispsToLose = _wispsToLoseOnReset;
        if (_collectedWisps.Count < _wispsToLoseOnReset)
        {
            wispsToLose = _collectedWisps.Count;
        }
        while (wispsToLose > 0)
        {
            _collectedWisps.Dequeue();
            wispsToLose--;
        }
        foreach(Vector3 position in _collectedWisps)
        {
            WispBehaviour wispInstance = _wispInstances[_wispMap[position]];
            wispInstance.Hide();
        }
    }

    public float GetWispCollectionPercent()
    {
        return (float)_collectedWisps.Count / _wispLocations.Length;
    }
}
