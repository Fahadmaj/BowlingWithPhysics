using UnityEngine;
using TMPro;
using System.Collections; // Required for coroutines

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallController ball;
    [SerializeField] private Transform pinAnchor; 
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Vector3[] initialPinPositions;
    private Quaternion[] initialPinRotations;
    private FallTrigger[] fallTriggers;
    private float score = 0;
    private bool isResetting = false; // Prevent duplicate resets

    private void Start()
    {
        StoreInitialPinState();
        inputManager.OnResetPressed.AddListener(HandleReset);
        RegisterFallTriggers();

        HandleReset(); // ✅ Test to ensure reset logic is running
    }

    private void StoreInitialPinState()
    {
        int pinCount = pinAnchor.childCount;
        initialPinPositions = new Vector3[pinCount];
        initialPinRotations = new Quaternion[pinCount];

        for (int i = 0; i < pinCount; i++)
        {
            Transform pin = pinAnchor.GetChild(i);
            initialPinPositions[i] = pin.position;
            initialPinRotations[i] = pin.rotation;

            Debug.Log($"📌 Stored Pin {i}: Position {initialPinPositions[i]}, Rotation {initialPinRotations[i]}");
        }
    }

    private void HandleReset()
    {
        if (isResetting) return; // Prevent duplicate resets
        isResetting = true;
        Debug.Log("🛠 HandleReset() called!");

        ball.ResetBall();
        ResetPins();
        ResetScore();

        StartCoroutine(ResetCooldown());
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(1f); // ✅ Prevents spamming reset
        isResetting = false;
    }

    private void ResetPins()
    {
        Debug.Log("🔄 ResetPins() is running...");

        int pinCount = pinAnchor.childCount;
        for (int i = 0; i < pinCount; i++)
        {
            Transform pin = pinAnchor.GetChild(i);

            // ✅ Ensure pin is active
            pin.gameObject.SetActive(false);
            pin.gameObject.SetActive(true);

            // ✅ Slightly raise the pins to avoid ground collision issues
            Vector3 adjustedPosition = initialPinPositions[i] + new Vector3(0, 0.2f, 0);
            pin.SetPositionAndRotation(adjustedPosition, initialPinRotations[i]);

            Debug.Log($"✅ Pin {i} repositioned to: {pin.position}, rotation: {pin.rotation}");

            // ✅ Reset Rigidbody physics properly
            Rigidbody pinRB = pin.GetComponent<Rigidbody>();
            if (pinRB != null)
            {
                pinRB.linearVelocity = Vector3.zero;
                pinRB.angularVelocity = Vector3.zero;
                StartCoroutine(ResetPhysics(pinRB));
            }

            // ✅ Reset FallTrigger so pins can detect falls again
            FallTrigger fallTrigger = pin.GetComponent<FallTrigger>();
            if (fallTrigger != null)
            {
                fallTrigger.ResetFall();
            }
        }

        RegisterFallTriggers();
    }

    private IEnumerator ResetPhysics(Rigidbody rb)
    {
        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = rb.position; // ✅ Ensures physics engine acknowledges reset
        yield return new WaitForSeconds(0.1f); // ✅ Small delay before reactivating
        rb.isKinematic = false;
    }

    private void RegisterFallTriggers()
    {
        Debug.Log("Registering fall triggers...");

        fallTriggers = pinAnchor.GetComponentsInChildren<FallTrigger>();

        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.RemoveAllListeners(); // ✅ Prevent duplicate event listeners
            pin.OnPinFall.AddListener(IncrementScore);
        }

        Debug.Log($"Total pins registered: {fallTriggers.Length}");
    }

    private void ResetScore()
    {
        score = 0;
        scoreText.text = $"Score: {score}";
        Debug.Log("Score reset to 0");
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
        Debug.Log($"Score updated: {score}");
    }
}
