using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMover : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private bool _isChanged = true;
    private float _speed = 2f;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void MoveToTargerPoint(Vector3 firstDirection, Vector3 secondDirection)
    {
        StartCoroutine(ToDirectOfMovement(firstDirection, secondDirection));
    }

    private IEnumerator ToDirectOfMovement(Vector3 firstDirection, Vector3 secondDirection)
    {
        while (true)
        {
            if (_isChanged)
            {
                Move(firstDirection);

                ChangeConditionForDirectionOfMovement(firstDirection, secondDirection);
            }
            else
            {
                Move(secondDirection);

                ChangeConditionForDirectionOfMovement(firstDirection, secondDirection);
            }

            yield return null;
        }
    }

    private void ChangeConditionForDirectionOfMovement(Vector3 firstDirection, Vector3 secondDirection)
    {
        if (transform.position == firstDirection)
        {
            _isChanged = false;
            _renderer.flipX = false;
        }

        if (transform.position == secondDirection)
        {
            _isChanged = true;
            _renderer.flipX = true;
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, _speed * Time.deltaTime);
    }
}