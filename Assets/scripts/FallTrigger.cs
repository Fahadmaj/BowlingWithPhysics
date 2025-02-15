using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new UnityEvent(); // Event for GameManager
    private bool isPinFallen = false; // Prevent multiple triggers

    private void OnTriggerEnter(Collider triggeredObject)
    {
        // Ensure only the first fall is detected and only when hitting the ground
        if (!isPinFallen && triggeredObject.CompareTag("Ground"))
        {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} has fallen!");
        }
    }
}