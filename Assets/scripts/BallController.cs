using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;

    private bool isBallLaunched;
    private Rigidbody ballRB;
    private InputManager inputManager;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        // Ensure InputManager is assigned
        inputManager = FindObjectOfType<InputManager>();
        if (inputManager != null)
        {
            inputManager.OnSpacePressed.AddListener(LaunchBall);
        }
        else
        {
            Debug.LogError("InputManager not found! Ensure it's in the scene.");
        }

        // Parent the ball to the ball anchor and reset its local position
        if (ballAnchor != null)
        {
            transform.SetParent(ballAnchor);  // Use SetParent() instead of transform.parent
            transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.LogError("BallAnchor is not assigned in the Inspector.");
        }

        // Prevent physics from affecting the ball before launch
        ballRB.isKinematic = true;
        ballRB.linearVelocity = Vector3.zero; // Ensure no unwanted movement
        ballRB.angularVelocity = Vector3.zero;
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;

        // Unparent the ball so it moves freely
        transform.SetParent(null);

        // Enable physics and apply force to launch the ball
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}