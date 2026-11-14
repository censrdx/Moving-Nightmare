using UnityEngine;
using UnityEngine.UI;

// Automatic restart timer when the player loses. Mostly here to prevent potential issues.
public class CountdownTimer : MonoBehaviour
{
    // Default values.
    private float _currentTime = 0f;
    private const float StartingTime = 20f;

    [SerializeField] private Text countdownText;

    // Start is called before the first frame update
    private void Start()
    {
        // Set current time to starting time
        _currentTime = StartingTime;
    }
    
    // Update is called once per frame
    private void Update()
    {   
        // Subtract the time passed in seconds since the last frame, making the timer tick down smoothly.
        _currentTime -= Time.deltaTime;
        // Convert _currentTime to string.
        countdownText.text = _currentTime.ToString("0");

        // Checks if the timer hit 0.
        if (_currentTime <= 0)
        {
            // Set timer to 0 so it doesn't display negative numbers.
            _currentTime = 0f;
        }
    }
}
