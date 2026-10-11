using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // This is a refrence to the game manager script.
    public GameManager gameManager;

    // This function runs when the player hits the end trigger.
    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();    // On trigger use the gameManager.CompleteLevel(); script
    }
}