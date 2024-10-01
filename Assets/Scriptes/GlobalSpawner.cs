using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GlobalSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyMover _enemyMover;
    private EnemyPointsSpawner _enemyPointSpawner;
    private List<Vector2> _coinSpawnPoints;
    private List<Vector2> _enemyStartPoints;
    private Vector3 _firstPosition;
    private Vector3 _secondPosition;

    private void Awake()
    {
        _coinSpawnPoints = GetComponent<CoinPointsSpawner>().CoordinatesOfPoins;
        _enemyPointSpawner = GetComponent<EnemyPointsSpawner>();
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
            var wait = new WaitForSeconds(0.3f);

            Instantiate(_coinPrefab, point, Quaternion.identity);

            yield return wait;
        }
    }

    private IEnumerator CreateSeveralEnemies()
    {
        foreach (var point in _enemyStartPoints)
        {
            var wait = new WaitForSeconds(1);

            _firstPosition = point;
            _secondPosition = _enemyPointSpawner.SetFinishCoordinates();

            Enemy enemy = Instantiate(_enemyPrefab, _firstPosition, Quaternion.identity);

            _enemyMover = enemy.GetComponent<EnemyMover>();
            _enemyMover.MoveToPoint(_secondPosition, _firstPosition);

            yield return wait;
        }
    }
}