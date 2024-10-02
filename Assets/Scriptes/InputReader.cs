using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode Jump = KeyCode.Space;
    private bool _isJump;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(HorizontalAxis);

        if (Input.GetKeyDown(Jump))
        {
            _isJump = true;
        }
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }

    public bool GetIsJump()
    {
        return GetBoolAsTrigger(ref _isJump);
    }
}