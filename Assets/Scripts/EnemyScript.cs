using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stoppingDistance = 5f;

    private void Update()
    {
        // Get the direction to the player
        Vector3 direction = player.position - transform.position;

        // Check if the player is within the stopping distance
        if (direction.magnitude < stoppingDistance)
        {
            // If so, stop moving
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
        {
            // Normalize the direction vector
            direction.Normalize();

            // Calculate the desired velocity
            Vector3 desiredVelocity = direction * speed;

            // Set the Rigidbody's velocity to the desired velocity
            GetComponent<Rigidbody>().velocity = desiredVelocity;
        }
    }
}