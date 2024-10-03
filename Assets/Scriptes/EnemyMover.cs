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

    private IEnumerator ToDirectOfMovement(Vector3 firstDirection, Vector3 secondDirection)
    {
        while (true)
        {
            if (_isChanged)
            {
                Move(firstDirection);
                ChangeConditionForDirectionOfMovment(firstDirection, secondDirection);

                _renderer.flipX = false;
            }
            else
            {
                Move(secondDirection);
                ChangeConditionForDirectionOfMovment(firstDirection, secondDirection);

                _renderer.flipX = true;
            }

            yield return null;
        }
    }

    private void ActivateCoroutine(Vector3 firstDirection, Vector3 secondDirection)
    {
        StartCoroutine(ToDirectOfMovement(firstDirection, secondDirection));
    }
    private void ChangeConditionForDirectionOfMovment(Vector3 firstDirection, Vector3 secondDirection)
    {
        if (transform.position == firstDirection)
        {
            _isChanged = false;
        }

        if (transform.position == secondDirection)
        {
            _isChanged = true;
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, _speed * Time.deltaTime);
    }

    public void MoveToPoint(Vector3 firstDirection, Vector3 secondDirection)
    {
        ActivateCoroutine(firstDirection, secondDirection);
    }
}