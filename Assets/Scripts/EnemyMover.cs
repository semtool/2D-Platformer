using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] EnemyVision _enemyVision;
    [SerializeField] float _speed;

    private bool _isWork = true;

    private void Awake()
    {
        _enemyVision = GetComponent<EnemyVision>();
    }

    private void Update()
    {
        foreach (var collider in _enemyVision.ToDetect())
        {
            if (collider.TryGetComponent(out Player player))
            {
                Move(player.transform.position);
            }
        }
    }

    public void MoveToNextPoint(IReadOnlyList<Vector2> pointsOfDirection)
    {
        StartCoroutine(ToNavigate(pointsOfDirection));
    }

    private IEnumerator ToNavigate(IReadOnlyList<Vector2> pointsOfDirection)
    {
        while (_isWork)
        {
            for (int i = 0; i < pointsOfDirection.Count; i++)
            {
                while (transform.position.x != pointsOfDirection[i].x && transform.position.y != pointsOfDirection[i].y)
                {
                    Move(pointsOfDirection[i]);

                    yield return null;
                }
            }
        }
    }

    private void Move(Vector3 point)
    {
        transform.position = Vector2.MoveTowards(transform.position, point, _speed * Time.deltaTime);
    }
}