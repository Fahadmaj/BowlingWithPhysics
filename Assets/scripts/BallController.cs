using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private GameObject launchIndicator;
    [SerializeField] float speed=10;
    private Rigidbody ballRB;
    private bool isBallLaunched;
    private InputManager inputManager;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager = FindObjectOfType<InputManager>();

        if (inputManager != null)
        {
            inputManager.OnSpacePressed.AddListener(LaunchBall);
        }

        ResetBall();
    }

    public void ResetBall()
    {
        isBallLaunched = false;

        ballRB.isKinematic = false;
        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;
        ballRB.isKinematic = true;

        transform.SetParent(ballAnchor);
        transform.localPosition = Vector3.zero;

        if (launchIndicator != null)
        {
            launchIndicator.SetActive(true);
        }
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;

        transform.SetParent(null);
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.transform.forward * speed, ForceMode.Impulse);

        if (launchIndicator != null)
        {
            launchIndicator.SetActive(false);
        }
    }
}