using UnityEngine;
using Unity.Cinemachine;

public class LaunchIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera freeLookCamera;
    [SerializeField] private Transform ball; // Reference to the ball

    private Vector3 offset = new Vector3(0, 0, 1.5f); // Keeps the indicator in front of the ball

    void Update()
    {
        if (ball == null || freeLookCamera == null) return;

        // Keep the indicator positioned in front of the ball
        transform.position = ball.position + ball.forward * offset.z;

        // Make the indicator face the same direction as the camera
        transform.forward = freeLookCamera.transform.forward;

        // Preserve only the Y-axis rotation
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}