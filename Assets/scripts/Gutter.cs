using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Ensure the ball has the tag "Ball"
        {
            Debug.Log("Ball entered the gutter!");
            ResetBall(other.gameObject);
        }
    }

    private void ResetBall(GameObject ball)
    {
        // Reset the ball position (Adjust the position to fit your game)
        ball.transform.position = new Vector3(0, 1, 0); // Change as needed
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero; // Stop ball movement
            rb.angularVelocity = Vector3.zero; // Stop spinning
        }
    }
}