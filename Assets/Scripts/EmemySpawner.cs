using UnityEngine;

public class EmemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoints;

    private Transform[] _allPointsTransform;
    private Vector2 _startPosition;

    private void Awake()
    {
        _allPointsTransform = new Transform[_spawnPoints.childCount];
    }

    private void Start()
    {
        CreateSeveralEnemies();
    }

    private void CreateSeveralEnemies()
    {
        for (int i = 0; i < _allPointsTransform.Length; i++)
        {
            _allPointsTransform[i] = _spawnPoints.GetChild(i);

            _startPosition = _allPointsTransform[i].position;

            Enemy enemy = Instantiate(_enemyPrefab, _startPosition, Quaternion.identity);

            if (_allPointsTransform[i].TryGetComponent(out EnemyNavigator navigator))
            {
                if (navigator.Router.Count > 0)
                {
                    enemy.MoveToPoint(navigator.Router);
                }
            }
        }
    }
}