using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    public void MoveToNextPoint(IReadOnlyList<Vector2> nextPoint)
    {
        _enemyMover.MoveToTargetPoint(nextPoint);
    }
}