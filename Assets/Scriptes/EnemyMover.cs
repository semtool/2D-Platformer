using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private bool _isSwiched = true;
    private float _speed = 2f;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void ActivateCoroutine(Vector3 firstDirection, Vector3 secondDirection)
    {
        StartCoroutine(DirectOfMovement(firstDirection, secondDirection));
    }

    private IEnumerator DirectOfMovement(Vector3 firstDirection, Vector3 secondDirection)
    {
        while (true)
        {
            if (_isSwiched)
            {
                Move(firstDirection);
                ChangeDirection(firstDirection, secondDirection);

                _renderer.flipX = false;
            }
            else
            {
                Move(secondDirection);
                ChangeDirection(firstDirection, secondDirection);

                _renderer.flipX = true;
            }

            yield return null;
        }
    }

    private void ChangeDirection(Vector3 firstDirection, Vector3 secondDirection)
    {
        if (transform.position == firstDirection)
        {
            _isSwiched = false;
        }

        if (transform.position == secondDirection)
        {
            _isSwiched = true;
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