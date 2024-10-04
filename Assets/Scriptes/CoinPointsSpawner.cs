using System.Collections.Generic;
using UnityEngine;

public class CoinPointsSpawner : MonoBehaviour
{
    public IReadOnlyList <Vector2> coordinatesOfPoins;

    private void Awake()
    {
        coordinatesOfPoins = new List<Vector2>()
        {
            new Vector2(1,-1f),
            new Vector2(-5, -1f),
            new Vector2(3, 2.6f),
            new Vector2(8.5f, 5f),
            new Vector2(5.5f, -3.4f),
            new Vector2(11.0f, -1.3f),
            new Vector2(-8.17f, 3.61f),
            new Vector2(4.92f, 5f),     
        };
    }
}