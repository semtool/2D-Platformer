using UnityEngine;

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

    private void Update()
    {
        if (_contactsDetector.IsGround)
        {
           _playerMover.Move(_inputReader.Direction);
        }
    }

    private void FixedUpdate()
    {         
        if (_inputReader.GetIsJump() && _contactsDetector.IsGround)
        {
            _playerMover.Jump();
        }
    }
}