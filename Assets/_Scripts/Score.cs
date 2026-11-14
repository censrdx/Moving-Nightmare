using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Measure the distance of the player.
    public Transform player;
    // Display the changed text.
    public Text scoreText;

    // Update is called once per frame
    public void Update()
    {
        scoreText.text = player.position.z.ToString("0");   // Update the score with the player distance.
    }
}
