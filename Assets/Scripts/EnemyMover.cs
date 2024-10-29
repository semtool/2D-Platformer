using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMover : MonoBehaviour
{
    private float _speed = 2f;
    private bool _isWork = true;

    public void MoveToTargetPoint(IReadOnlyList<Vector2> vectors)
    {
        StartCoroutine(SetRout(vectors));
    }

    private IEnumerator SetRout(IReadOnlyList<Vector2> pointsOfRout)
    {
        Vector2 startPosition = transform.position;

        while (_isWork)
        {
            for (int i = 0; i < pointsOfRout.Count; i++)
            {
                while (transform.position.x != pointsOfRout[i].x && transform.position.y != pointsOfRout[i].y)
                {
                    Move(pointsOfRout[i]);

                    yield return null;
                }
            }

            while (transform.position.x != startPosition.x && transform.position.y != startPosition.y)
            {
                Move(startPosition);

                yield return null;
            }
        }
    }

    private void Move(Vector2 point)
    {
        transform.position = Vector2.MoveTowards(transform.position, point, _speed * Time.deltaTime);
    }
}