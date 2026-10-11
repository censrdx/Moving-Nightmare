using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private string nextLevel = "Level02";
    [SerializeField] private int levelToUnlock = 2;

    private void Start()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
    // Called when the player successfully beats the level
    public void LoadNextLevel()
    {
        // Check what level the player has already reached
        int currentLevelReached = PlayerPrefs.GetInt("levelReached", 1);

        // Only update progress if this level unlocks a higher milestone than before
        if (levelToUnlock > currentLevelReached)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
            PlayerPrefs.Save(); // Safely save the progress to disk
        }

        // Proceed to the next level
        SceneManager.LoadScene(nextLevel);
    }

    // Public reference to the GameManager component.
    public void Restart()
    {
        // Call the restart function from GameManager.
        GameManager.Instance.Restart();
    }

    // This is a public reference to the GameManager component called.
    public void LoadMenu()
    {
        // Call the LoadMenu function from GameManager.
        GameManager.Instance.LoadMenu();
    }
}
