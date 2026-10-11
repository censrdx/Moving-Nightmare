using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Mark gameHasEnded to false.
    public static bool GameIsOver;

    // Mark LevelIsCompleted to false.
    public static bool LevelIsCompleted;

    // Adjustable "restartDelay" in the inspector
    public float restartDelay = 1f;

    // This is a public reference to the GameObject Component called completeLevelUI.
    public GameObject completeLevelUI;

    // This is a public reference to the GameObject Component call gameOverUI.
    public GameObject gameOverUI;

    // This is a public reference to the GameManager component called "GameManager.CompleteLevel".
    public void CompleteLevel()
    {
        if (LevelIsCompleted) return;
        Cursor.visible = true;
        LevelIsCompleted = true;
        Debug.Log("Level Completed"); // Display Level Completed message to the console.
        completeLevelUI.SetActive(true); // Set complete level ui to active
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Marked GameIsOver as false so it does not start the game as over.
        GameIsOver = false;
        // Marked LevelIsCompleted as false so it does not start the game as completed.
        LevelIsCompleted = false;
        //Make cursor invisible.
        Cursor.visible = false;
    }

    // This is a public reference to the GameManager component called "GameManager.EndGame".
    public void EndGame()
    {
        if (GameIsOver == false)
        {
            Cursor.visible = true; //Make cursor invisible.
            GameIsOver = true;
            Debug.Log("GAME OVER"); // Display GAME OVER message to the console.
            Invoke("Restart", restartDelay);    // Call restart delay.
            gameOverUI.SetActive(true);  // Enable game over ui.
        }
    }

    // This is a public refrence to the GameManager component called "GameManager.Restart".
    public void Restart()
    {
        // Load the last level that the player was.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // This is a public refrence to the GameManager component called "GameManager.LoadMenu".
    public void LoadMenu()
    {
        // Get menu scene from build index and load it.
        SceneManager.LoadScene("Menu");     
    }
}
