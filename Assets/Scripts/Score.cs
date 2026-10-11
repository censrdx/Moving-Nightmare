using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Variable To Messure The Distance Of The Player
    public Transform player;
    // Variable In Order To Display The Changed Text
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");   // Update The Score With The Player Distance
    }
}
