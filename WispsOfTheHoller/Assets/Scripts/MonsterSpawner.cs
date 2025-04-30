using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnPointContainer;
    private Transform[] _spawnPoints;
    [SerializeField]
    private GameObject _monsterToSpawn;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnPointContainer.transform.childCount];
        for (int i = 0; i < _spawnPointContainer.transform.childCount; i++)
        {
            Transform spawnPoint = _spawnPointContainer.transform.GetChild(i);
            _spawnPoints[i] = spawnPoint;
        }
        int diceRoll = Random.Range(0, _spawnPoints.Length);
        Instantiate(_monsterToSpawn, _spawnPoints[diceRoll].position, Quaternion.identity);
    }
}
