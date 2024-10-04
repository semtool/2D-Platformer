using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private float _timeOfDelay = 0.3f;
    private float _positiveLimit = 0.1f;
    private float _negativeLimit = -0.1f;
    private bool _hasUpType = true;
    private bool _hasDownType = false;
    private WaitForSeconds _intervalToNewFase;

    public int Jumping { get; private set; }

    public int Moving { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _intervalToNewFase = new WaitForSeconds(_timeOfDelay);

        AppointParameters();
    }

    private void Start()
    {
        ExtractParameters();
    }

    public void Move(float direction)
    {
        TurnFrontToRight(direction);

        TurnFrontToLeft(direction);

        _animator.SetFloat(Moving, Math.Abs(direction));

        _rigidbody.velocity = new Vector2(_speedX * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);

        _rigidbody.AddForce(new Vector2(0, _jumpForce));

        StartCoroutine(ChangeFaseOfJump());
    }

    private IEnumerator ChangeFaseOfJump()
    {
        ChangeJumpPhaseToUp();

        yield return _intervalToNewFase;

        ChangeJumpPhaseToDown();
    }

    private void AppointParameters()
    {
        Jumping = Animator.StringToHash(nameof(Jumping));
        Moving = Animator.StringToHash(nameof(Moving));
    }

    private void ExtractParameters()
    {
        _animator.GetBool(Jumping);
        _animator.GetBool(Moving);
    }

    private void ChangeJumpPhaseToUp()
    {
        _animator.SetBool(Jumping, _hasUpType);
    }

    private void ChangeJumpPhaseToDown()
    {
        _animator.SetBool(Jumping, _hasDownType);
    }

    private void TurnFrontToRight(float direction)
    {
        if (direction > _positiveLimit)
        {
            _renderer.flipX = false;
        }
    }

    private void TurnFrontToLeft(float direction)
    {
        if (direction < _negativeLimit)
        {
            _renderer.flipX = true;
        }
    }
}