using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new UnityEvent(); // Event for GameManager
    private bool isPinFallen = false; // Prevent multiple triggers

    private void OnTriggerEnter(Collider triggeredObject)
    {
        if (!isPinFallen && triggeredObject.CompareTag("Ground"))
        {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} has fallen!"); // ✅ Debug log
        }
    }

    // ✅ Reset this when the game resets
    public void ResetFall()
    {
        isPinFallen = false;
    }
}