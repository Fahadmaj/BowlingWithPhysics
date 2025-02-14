using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    private Rigidbody ballRB;
    private bool isBallLaunched;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        // Find the InputManager in the scene
        InputManager inputManager = FindObjectOfType<InputManager>();

        if (inputManager != null)
        {
            inputManager.OnSpacePressed.AddListener(LaunchBall);
        }
        else
        {
            Debug.LogError("InputManager not found! Make sure it exists in the scene.");
        }
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return; // Prevent multiple launches

        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}