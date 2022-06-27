using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    // Скрипт в игре не учавствует
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _coin;

    private Transform[] _spawnPoints;
    private int _currentSpawnPoint = 0;

    private void Awake()
    {
        _spawnPoints = new Transform[_spawnPoint.childCount];

        for(int i = 0; i < _spawnPoint.childCount; i++)
        {
            _spawnPoints[i] = _spawnPoint.GetChild(i);
        }

        CreateCoins();
    }

    private void CreateCoins()
    {
        while(_currentSpawnPoint != _spawnPoint.childCount)
        {
            Instantiate(_coin, _spawnPoints[_currentSpawnPoint]);
            _currentSpawnPoint++;

        }
    }
}
