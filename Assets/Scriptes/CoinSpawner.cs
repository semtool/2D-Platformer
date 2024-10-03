using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinPointsSpawner))]

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private List<Vector2> _coinSpawnPoints;
    private WaitForSeconds _intervalToNewCoin;
    private float _timeForCoinInterval = 0.3f;

    private void Awake()
    {
        _coinSpawnPoints = GetComponent<CoinPointsSpawner>().CoordinatesOfPoins;
        _intervalToNewCoin = new WaitForSeconds(_timeForCoinInterval);
    }

    private void Start()
    {
        StartCoroutine(CreateSeveralCoins());
    }

    private IEnumerator CreateSeveralCoins()
    {
        foreach (var point in _coinSpawnPoints)
        {
            yield return _intervalToNewCoin;

            Instantiate(_coinPrefab, point, Quaternion.identity);
        }
    }
}