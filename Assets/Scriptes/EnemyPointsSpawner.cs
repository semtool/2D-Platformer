using System.Collections.Generic;
using UnityEngine;

public class EnemyPointsSpawner : MonoBehaviour
{
    [SerializeField] float _minCoordinate;
    [SerializeField] float _maxCoordinate;

    private List<Vector2> _startCoordinates;

    public List<Vector2> StartCoordinatesOfEnemies => _startCoordinates;

    private void Awake()
    {
        _startCoordinates = new List<Vector2>()
        {
            SetCoordinates(9.6f, 0f),
            SetCoordinates(-3.21f, 5.4f),
        };
    }

    private Vector2 SetCoordinates(float coordinateX, float coordinateY)
    {
        return new Vector2 (coordinateX, coordinateY);
    }

    private float GetRandomCoordinate()
    {
        return Random.Range(_minCoordinate, _maxCoordinate);
    }

    public Vector2 SetFinishCoordinates()
    {
        return new Vector2(GetRandomCoordinate(), GetRandomCoordinate());
    }
}