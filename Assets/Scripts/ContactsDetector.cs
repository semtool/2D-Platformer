using UnityEngine;

public class ContactsDetector : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    public bool IsCetched { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Surface surface))
        {
            IsGrounded = true;         
        }

        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.ChangeStatus();
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Surface surface))
        {
            IsGrounded = false;
        }
    }
}