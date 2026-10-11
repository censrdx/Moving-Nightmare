using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // This function runs when the player hits the end trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Only trigger the win state if the colliding object is tagged as "Player".
        if (other.CompareTag("Player")) 
        {
            GameManager.Instance.CompleteLevel(); // On trigger the player completes the level.  
        }
    }
}