using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WispManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _wispLocations;
    [SerializeField]
    private GameObject _wispPrefab;
    private GameObject[] _wispInstances;
    private Queue<WispBehaviour> _collectedWisps;
    [SerializeField]
    private int _wispsToLoseOnReset = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collectedWisps = new Queue<WispBehaviour>();
        _wispInstances = new GameObject[_wispLocations.Length];
        for (int i = 0; i < _wispLocations.Length; i++)
        {
            GameObject wispInstance = Instantiate(_wispPrefab, _wispLocations[i].transform.position, Quaternion.identity);
            WispBehaviour instanceBehaviour = wispInstance.GetComponent<WispBehaviour>();
            instanceBehaviour.Initialise(this);
            _collectedWisps.Enqueue(instanceBehaviour);
        }
    }

    public void MarkCollected(WispBehaviour collectedWisp)
    {
        _collectedWisps.Enqueue(collectedWisp);
    }

    public void ResetCollection()
    {
        int wispsToLose = _wispsToLoseOnReset;
        if (_collectedWisps.Count < _wispsToLoseOnReset)
        {
            wispsToLose = _collectedWisps.Count;
        }
        while (wispsToLose > 0)
        {
            WispBehaviour wispInstance = _collectedWisps.Dequeue();
            wispInstance.ResetWisp();
        }
    }
}
