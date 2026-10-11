using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // A reference to the PlayerMovement script.
    public PlayerMovement movement;
    
    // Get information about the collision and call it "CollisionInfo".
    public void OnCollisionEnter(Collision collisionInfo)
    {
        // Check if the object and the player collided with a tag called "obstacle".
        if (collisionInfo.gameObject.CompareTag("Obstacle"))
        {
            movement.enabled = false; // Disable player movement.
            GameManager.Instance.EndGame(); // Find object from game manager in order to end the game.
        }
    }
}
