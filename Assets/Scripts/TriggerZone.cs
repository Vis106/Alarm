using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _enteredZone;
    [SerializeField] private UnityEvent _leftZone;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            _enteredZone?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            _leftZone?.Invoke();
        }
    }
}