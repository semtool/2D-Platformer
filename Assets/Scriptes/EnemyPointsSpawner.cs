using System.Collections.Generic;
using UnityEngine;

public class EnemyPointsSpawner : MonoBehaviour
{
    [SerializeField] private float _minCoordinate;
    [SerializeField] private float _maxCoordinate;

    public IReadOnlyList<Vector2> startCoordinatesOfEnemies;

    private void Awake()
    {
        startCoordinatesOfEnemies = new List<Vector2>()
        {
            SetCoordinates(-5f,-3f),
            SetCoordinates( -3.21f, 5.4f),
        };
    }

    public Vector2 SetFinishCoordinates()
    {
        return new Vector2(GetRandomCoordinate(), GetRandomCoordinate());
    }

    private Vector2 SetCoordinates(float coordinateX, float coordinateY)
    {
        return new Vector2(coordinateX, coordinateY);
    }

    private float GetRandomCoordinate()
    {
        return Random.Range(_minCoordinate, _maxCoordinate);
    }
}