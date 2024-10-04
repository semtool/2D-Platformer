using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CoinPointsSpawner))]

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private CoinPointsSpawner _coinSpawner;
    private WaitForSeconds _intervalToNewCoin;
    private float _timeForCoinInterval = 0.3f;

    private void Awake()
    {
        _coinSpawner = GetComponent<CoinPointsSpawner>();
        _intervalToNewCoin = new WaitForSeconds(_timeForCoinInterval);
    }

    private void Start()
    {
        StartCoroutine(CreateSeveralCoins());
    }

    private IEnumerator CreateSeveralCoins()
    {
        foreach (var point in _coinSpawner.coordinatesOfPoins)
        {
            yield return _intervalToNewCoin;

            Instantiate(_coinPrefab, point, Quaternion.identity);
        }
    }
}