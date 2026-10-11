using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Set GameIsPaused to false by default.
    private static bool _gameIsPaused;
    
    // This is a reference to the PauseMenuUI component.
    [SerializeField] private GameObject pauseMenuUI;

    // This is a reference to the ScoreTextUI component.
    [SerializeField] private GameObject scoreTextUI;

    // Start is called before the first frame update.
    private void Start()
    {
        // Start the game normally and not paused.
        Time.timeScale = 1f;
        _gameIsPaused = false;
        Cursor.visible = false; // Make the cursor invisible.
        Cursor.lockState = CursorLockMode.Locked; // Make cursor locked in position.
        pauseMenuUI.SetActive(false);
        scoreTextUI.SetActive(true);
    }

    // Update is called once per frame.
    private void Update()
    {
        // Check whether the player wants to pause the game.
        // Get Escape key from keyboard
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused) // If GameIsPaused is equal to true.
            {
                Resume(); // Call Resume() function.
            }
            else
            {
                Pause(); //Call Pause() function.
            }
        }
    }

    // Update called at regular, fixed intervals as part of Unity's physics update loop.
    public void FixedUpdate()
    {
        // Disable controls while LevelIsCompleted.
        if (GameManager.LevelIsCompleted)
        {
            this.enabled = false;
            return;
        }

        // Disable controls while GameIsOver.
        if (!GameManager.GameIsOver) return;
        this.enabled = false;
    }

    // This is a reference to the PauseMenuUI component.
    public void Resume()
    {
        // Return time back to normal.
        Time.timeScale = 1f;
        // Set game is paused to false.
        _gameIsPaused = false;
        //Make cursor invisible.
        Cursor.visible = false;
        // Make cursor locked in position.
        Cursor.lockState = CursorLockMode.Locked;
        // Disable Pause Menu.
        pauseMenuUI.SetActive(false);
        // Enable score text ui.
        scoreTextUI.SetActive(true);
    }
    
    // This is a reference to the PauseMenuUI component.
    private void Pause()
    {
        // Freeze time.
        Time.timeScale = 0f;
        // Set game is paused to true.
        _gameIsPaused = true;
        //Make cursor visible.
        Cursor.visible = true;
        // Unlock cursor.
        Cursor.lockState = CursorLockMode.None;
        // Activate the Pause Menu.
        pauseMenuUI.SetActive(true);
        // Deactivate the score ui while pause menu is active.
        scoreTextUI.SetActive(false);
    }

    // Public reference to the PauseMenuUI component.
    public void LoadMenu()
    {
        // Get menu scene from build index and load it.
        SceneManager.LoadScene("Menu");
        // Set game is paused to false.
        _gameIsPaused = false;
        // Make cursor visible.
        Cursor.visible = true;
        // Unlock cursor.
        Cursor.lockState = CursorLockMode.None;
    }

    // Public reference to the PauseMenuUI component called.
    public void Restart()
    {
        // Load the last level that the player was.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Set game is paused to false.
        _gameIsPaused = false;
        //Make cursor invisible.
        Cursor.visible = false;
        // Unlock cursor.
        Cursor.lockState = CursorLockMode.None;
    }
}