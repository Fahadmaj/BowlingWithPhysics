using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Ensure the ball has the tag "Ball"
        {
            Rigidbody ballRigidBody = other.GetComponent<Rigidbody>();
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;
            ballRigidBody.AddForce(transform.up * velocityMagnitude, ForceMode.VelocityChange);

        }
   }
}