using UnityEngine;

[RequireComponent(typeof(PlayerMover))] 
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(ContactsDetector ))]

public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private ContactsDetector _contactsDetector;
    private InputReader _inputReader;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _inputReader = GetComponent<InputReader>();
        _contactsDetector = GetComponent<ContactsDetector>();
    }

    private void FixedUpdate()
    {
        if (_contactsDetector.IsGround)
        {
            _playerMover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _contactsDetector.IsGround)
        {
            _playerMover.Jump();
        }
    }
}