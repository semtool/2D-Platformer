using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool IsTouched { get; private set; }

    private void FixedUpdate()
    {
        if (IsTouched)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeStatus()
    {
        IsTouched = true;
    }
}