using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyPointsSpawner))]

public class EmemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyPointsSpawner _enemyPointSpawner;
    private WaitForSeconds _intervalToNewEnemy;
    private float _timeForEnemyInterval = 1;
    private Vector3 _firstPosition;
    private Vector3 _secondPosition;

    private void Awake()
    {
        _enemyPointSpawner = GetComponent<EnemyPointsSpawner>();
        _intervalToNewEnemy = new WaitForSeconds(_timeForEnemyInterval);
    }

    private void Start()
    {
        StartCoroutine(CreateSeveralEnemies());
    }

    private IEnumerator CreateSeveralEnemies()
    {
        foreach (var point in _enemyPointSpawner.startCoordinatesOfEnemies)
        {
            yield return _intervalToNewEnemy;

            _firstPosition = point;
            _secondPosition = _enemyPointSpawner.SetFinishCoordinates();

            Enemy enemy = Instantiate(_enemyPrefab, _firstPosition, Quaternion.identity);

            enemy.Move(_secondPosition, _firstPosition);
        }
    }
}
