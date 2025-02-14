using UnityEngine;
using Unity.Cinemachine;

public class LaunchIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCamera;
    [SerializeField] private Transform ball; 

    private Vector3 offset = new Vector3(0, 0, 1.5f); 

    void Update()
    {
        if (ball == null || freeLookCamera == null) return;

        
        transform.position = ball.position + freeLookCamera.transform.forward * offset.z;

        
        transform.forward = freeLookCamera.transform.forward;

        
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}