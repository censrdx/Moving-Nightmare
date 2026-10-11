using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // A refrence to the PlayerMovement script.
    public PlayerMovement movement;

    // This function runs when we hit another object.
    // Get information about the collision and call it "CollitionInfo".
    public void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        // Check if the object the player collided with has a tag called "obstacle".
        if (collisionInfo.gameObject.tag == "Obstacle") 
        {
            movement.enabled = false; // Disable player movement.
            FindObjectOfType<GameManager>().EndGame(); // Find object from game manager in order to end the game.
        }
    }
}
