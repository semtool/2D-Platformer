using System.Collections.Generic;
using UnityEngine;

public class EnemyPointsSpawner : MonoBehaviour
{
    [SerializeField] float _minCoordinate;
    [SerializeField] float _maxCoordinate;

    public List<Vector2> StartCoordinatesOfEnemies { get; private set; }

    private void Awake()
    {
        StartCoordinatesOfEnemies = new List<Vector2>()
        {
            SetCoordinates(-5f,-3f),
            SetCoordinates( -3.21f, 5.4f),
        };
    }

    private Vector2 SetCoordinates(float coordinateX, float coordinateY)
    {
        return new Vector2(coordinateX, coordinateY);
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