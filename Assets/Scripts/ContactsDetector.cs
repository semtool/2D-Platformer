using UnityEngine;

public class ContactsDetector : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    public bool IsCatched { get; private set; }

    public bool IsCured { get; private set; }


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
            IsCatched = true;
        }

        if (collision.gameObject.TryGetComponent(out Pill pill))
        {
            pill.ChangeStatus();

            IsCured = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Surface surface))
        {
            IsGrounded = false;
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            IsCatched = false;
        }
    }

    public void ChgangeCureStatus()
    {
        IsCured = false;
    }
}