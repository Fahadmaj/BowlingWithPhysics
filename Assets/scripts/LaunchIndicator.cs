using UnityEngine;
using Unity.Cinemachine;

public class LaunchIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineCamera freeLookCamera;
    [SerializeField] private Transform ball;

    private Vector3 offset = new Vector3(0, 0, 1.5f);

    void Update()
    {
        transform.forward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        
    }
}