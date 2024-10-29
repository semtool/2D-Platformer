using System.Collections.Generic;
using UnityEngine;

public class EmemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<EnemyNovigator> _enemies;

    private Vector2 _startPosition;

    private void Start()
    {
        CreateSeveralEnemies();
    }

    private void CreateSeveralEnemies()
    {
        foreach (var unit in _enemies)
        {
            if (unit.TryGetComponent(out EnemyNovigator enemyNavigator))
            {
                _startPosition = unit.transform.position;

                Enemy enemy = Instantiate(_enemyPrefab, _startPosition, Quaternion.identity);

                if (enemyNavigator.GetAllPoints().Count > 0)
                {
                    enemy.MoveToNextPoint(enemyNavigator.GetAllPoints());
                }
            }
        }
    }
}