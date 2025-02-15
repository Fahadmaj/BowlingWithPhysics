using UnityEngine;
using Unity.Cinemachine;

public class LaunchIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCamera;
    [SerializeField] private Transform ball; 

    private Vector3 offset = new Vector3(0, 0, 1.5f); 

    void Update()
    {
        if (ball == null || freeLookCamera == null)
        {
            Debug.LogError("LaunchIndicator: Ball or FreeLook Camera is not assigned!");
            return;
        }

        // ✅ Keep the indicator positioned in front of the ball
        Vector3 forward = freeLookCamera.transform.forward;
        forward.y = 0; // Ignore vertical tilt
        transform.position = ball.position + forward.normalized * offset.z;

        // ✅ Ensure the indicator only rotates on the Y-axis
        transform.forward = forward.normalized;
    }
}