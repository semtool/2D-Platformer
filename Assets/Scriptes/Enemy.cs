using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    public void Move(Vector3 firstDirection, Vector3 secondDirection)
    {
        _enemyMover.MoveToPoint(firstDirection, secondDirection);
    }
}