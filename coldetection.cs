using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    public int collisionValue = 0; // This will be set to 1 upon collision with the rock

    // OnCollisionEnter is called when this GameObject collides with another
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the tag "rock"
        if (collision.gameObject.CompareTag("terrain"))
        {
            collisionValue = 1;  // Set the integer value to 1 when colliding with a rock
            Debug.Log("Collided with a rock! collisionValue set to 1");
        }
    }
}
