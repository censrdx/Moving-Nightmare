using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Set GameIsPaused to false by default.
    public static bool GameIsPaused = false;

    // This is a refrence to the PauseMenuUI component.
    public GameObject pauseMenuUI;

    // This is a refrence to the ScoreTextUI component.
    public GameObject scoreTextUI;

    // Start is called before the first frame update.
    void Start()
    {
        // Start the game normaly and not paused.
        pauseMenuUI.SetActive(false);
        scoreTextUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.visible = false; // Make cursor invisible.
    }

    // Update is called once per frame.
    void Update()
    {
        // Check whether or not the player wants to pause the game.
        // Get Escape key from keyboard
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)   // If GameIsPaused is equal to true.
            {
                Resume();   // Call Resume() function.
            }
            else
            {
                Pause();    //Call Pause() function.
            }
        }
    }

    void FixedUpdate()
    {
        // Disable controlls while LevelIsCompleted.
        if (GameManager.LevelIsCompleted)
        {
            this.enabled = false;
            return;
        }

        // Disable controlls while GameIsOver.
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }
    }

    // This is a refrence to the PauseMenuUI component called "PauseMenu.Resume".
    public void Resume()
    {
        //Make cursor invisible.
        Cursor.visible = false;
        // Disable Pause Menu.
        pauseMenuUI.SetActive(false);
        // Enable score text ui.
        scoreTextUI.SetActive(true);
        // Return time back to normal.
        Time.timeScale = 1f;
        // Set game is paused to false.
        GameIsPaused = false;
    }

    // This is a refrence to the PauseMenuUI component called "PauseMenu.Pause".
    void Pause()
    {
        // Activate the Pause Menu.
        pauseMenuUI.SetActive(true);
        // Deactivate the score ui while pause menu is active.
        scoreTextUI.SetActive(false);
        // Freeze time.
        Time.timeScale = 0f;
        // Set game is paused to true.
        GameIsPaused = true;
        //Make cursor visible.
        Cursor.visible = true;
    }

    // This is a public refrence to the PauseMenuUI component called "PauseMenu.LoadMenu".
    public void LoadMenu()
    {
        // Get menu scene from build index and load it.
        SceneManager.LoadScene("Menu");
        // Set game is paused to false.
        GameIsPaused = false;
        // //Make cursor visible.
        Cursor.visible = true;
    }

    // This is a public refrence to the PauseMenuUI component called "PauseMenu.Restart".
    public void Restart()
    {
        // Load the last level that the player was.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Set game is paused to false.
        GameIsPaused = false;
        //Make cursor invisible.
        Cursor.visible = false;
    }
}