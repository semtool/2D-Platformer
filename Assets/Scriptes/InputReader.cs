using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    private bool _isJump;

    public float Direction { get; private set; }


    private void Update()
    {
        Direction = Input.GetAxis(HorizontalAxis);

        if (Input.GetKeyDown(KeyCode.Space))
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