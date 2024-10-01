using System.Collections.Generic;
using UnityEngine;

public class CoinPointsSpawner : MonoBehaviour
{
    private List<Vector2> _coordinatsOfPoins;

    public List<Vector2> CoordinatesOfPoins => _coordinatsOfPoins;

    private void Awake()
    {
        _coordinatsOfPoins = new List<Vector2>()
        {
            GetRandomCoordinates(1,-1f),
            GetRandomCoordinates(-5, -1f),
            GetRandomCoordinates(3, 2.6f),
            GetRandomCoordinates(8.5f, 5f),
            GetRandomCoordinates(5.5f, -3.4f),
            GetRandomCoordinates(11.0f, -1.3f),
            GetRandomCoordinates(-8.17f, 3.61f),
            GetRandomCoordinates(4.92f, 5f),     
        };
    }

    private Vector2 GetRandomCoordinates(float cpordinateX, float coordinateY)
    {
        return new Vector2(cpordinateX, coordinateY);
    }
}