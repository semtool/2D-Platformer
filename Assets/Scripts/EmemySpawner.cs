using UnityEngine;

[RequireComponent(typeof(EnemyPointsSpawner))]

public class EmemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyPointsSpawner _enemyPointSpawner;
    private Vector3 _firstPosition;
    private Vector3 _secondPosition;

    private void Awake()
    {
        _enemyPointSpawner = GetComponent<EnemyPointsSpawner>();
    }

    private void Start()
    {
      CreateSeveralEnemies();
    }

    private void CreateSeveralEnemies()
    {
        foreach (var point in _enemyPointSpawner.startCoordinatesOfEnemies)
        {
            _firstPosition = point;
            _secondPosition = _enemyPointSpawner.SetFinishCoordinates();

            Enemy enemy = Instantiate(_enemyPrefab, _firstPosition, Quaternion.identity);

            enemy.Move(_secondPosition, _firstPosition);
        }
    }
}