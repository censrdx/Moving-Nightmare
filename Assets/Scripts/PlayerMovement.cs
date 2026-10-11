using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    // This is a refrence to the rigidbody component called "rb".
    public Rigidbody rb;

    // Adjustable "forwardForce" in the inspector
    public float forwardForce = 2000f;

    // Adjustable "sidewaysForce" in the inspector
    public float sidewaysForce = 500f;

    // I marked this as "FixedUpdated" because I am using it to mess with physics.
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // If player is pressing the D key
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Add force to the right side.
        }

        // If player is pressing the a key
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Add force to the left side.
        }

        // If player go below 0.9 the game ends
        if (rb.position.y < 0.9f)
        {
            // Find object from game manager in order to end the game.
            FindObjectOfType<GameManager>().EndGame();
        }

        // Disable controlls while GameIsOver.
        if (GameManager.GameIsOver) 
        {
            this.enabled = false;
            return;
        }

        // Disable controlls while LevelIsCompleted.
        if (GameManager.LevelIsCompleted)
        {
            this.enabled = false;
            return;
        }
    }
}
