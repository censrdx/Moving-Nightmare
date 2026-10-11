using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    // Next level == Level02.
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    // This is a public reference to the LevelComplete component called "LevelComplete.LoadNextLevel".
    public void LoadNextLevel()
    {
        // Unlock the next level in the array.
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // Proceed to the next level
        SceneManager.LoadScene(nextLevel);
    }

    // This is a public reference to the GameManager component called "GameManager.Restart".
    public void Restart()
    {
        // Unlock the next level in the array.
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // Find the Restart function from GameManager and use it.
        //FindObjectOfType<GameManager>().Restart();
        FindAnyObjectByType<GameManager>().Restart();
    }

    // This is a public reference to the GameManager component called "GameManager.LoadMenu".
    public void LoadMenu()
    {
        // Unlock the next level in the queue.
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        // Find the LoadMenu function from GameManager and use it.
        FindObjectOfType<GameManager>().LoadMenu();
    }
}
