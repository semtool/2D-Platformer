using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _spawnPoints;

    private Transform[] _allPointsTransform;

    private void Awake()
    {
        _allPointsTransform = new Transform[_spawnPoints.childCount];
    }
    private void Start()
    {
        CreateSeveralCoins();
    }

    private void CreateSeveralCoins()
    {
        for (int i = 0; i < _allPointsTransform.Length; i++)
        {
            _allPointsTransform[i] = _spawnPoints.GetChild(i);

            Instantiate(_coinPrefab, _allPointsTransform[i].position, Quaternion.identity);
        }
    }
}