using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GlobalSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyPointsSpawner _enemyPointSpawner;
    private List<Vector2> _coinSpawnPoints;
    private List<Vector2> _enemyStartPoints;
    private Vector3 _firstPosition;
    private Vector3 _secondPosition;
    private WaitForSeconds _intervalToNewCoin;
    private WaitForSeconds _intervalToNewEnemy;
    private float _timeForCoinInterval = 0.3f;
    private float _timeForEnemyInterval = 1;

    private void Awake()
    {
        _coinSpawnPoints = GetComponent<CoinPointsSpawner>().CoordinatesOfPoins;
        _enemyPointSpawner = GetComponent<EnemyPointsSpawner>();
        _intervalToNewCoin = new WaitForSeconds(_timeForCoinInterval);
        _intervalToNewEnemy = new WaitForSeconds(_timeForEnemyInterval);
    }

    private void Start()
    {
        _enemyStartPoints = _enemyPointSpawner.StartCoordinatesOfEnemies;
        StartCoroutine(CreateSeveralCoins());
        StartCoroutine(CreateSeveralEnemies());
    }

    private IEnumerator CreateSeveralCoins()
    {
        foreach (var point in _coinSpawnPoints)
        {
            yield return _intervalToNewCoin;

            Instantiate(_coinPrefab, point, Quaternion.identity);
        }
    }

    private IEnumerator CreateSeveralEnemies()
    {
        foreach (var point in _enemyStartPoints)
        {
            yield return _intervalToNewEnemy;

            _firstPosition = point;
            _secondPosition = _enemyPointSpawner.SetFinishCoordinates();

            Enemy enemy = Instantiate(_enemyPrefab, _firstPosition, Quaternion.identity);

            enemy.Move(_secondPosition, _firstPosition);
        }
    }
}