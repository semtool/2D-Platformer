using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinPointsSpawner))]

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<CoinPointsSpawner> _coinsPoints;

    private void Start()
    {
        CreateSeveralCoins();
    }

    private void CreateSeveralCoins()
    {
        foreach (var point in _coinsPoints)
        {
            if (point.TryGetComponent(out CoinPointsSpawner pointsSpawner))
            {
                Instantiate(_coinPrefab, point.transform.position, Quaternion.identity);
            }
        }
    }
}