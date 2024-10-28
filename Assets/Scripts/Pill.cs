using UnityEngine;

public class Pill : MonoBehaviour
{
    private float _healthDose = 10;
    private bool _isUsed;

    public float HealthDortion { get; private set; }

    private void Awake()
    {
        HealthDortion = _healthDose;
    }

    private void FixedUpdate()
    {
        if (_isUsed)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeStatus()
    {
        _isUsed = true;
    }
}