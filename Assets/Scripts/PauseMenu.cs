using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Set GameIsPaused to false by default.
    private static bool _gameIsPaused;
    
    // This is a reference to the PauseMenuUI component.
    [SerializeField] private GameObject pauseMenuUI;

    // This is a reference to the ScoreTextUI component.
    [SerializeField] private GameObject scoreTextUI;

    [SerializeField] private InputActionReference pauseAction;
    
    // Start is called before the first frame update.
    private void Awake()
    {
        // Start the game normally and not paused.
        Time.timeScale = 1f;
        _gameIsPaused = false;
        Cursor.visible = false; // Make the cursor invisible.
        Cursor.lockState = CursorLockMode.Locked; // Make cursor locked in position.
        pauseMenuUI.SetActive(false);
        scoreTextUI.SetActive(true);
    }
    
    // Called when a component of an active GameObject is first enabled.
    private void OnEnable()
    {
        pauseAction.action.performed += OnPausePerformed;
        pauseAction.action.Enable();
    }

    // Called when a component itself is disabled or its parent GameObject is deactivated.
    private void OnDisable()
    {
        pauseAction.action.performed -= OnPausePerformed;
        pauseAction.action.Disable();
        
    }

    // Called automatically when input action is triggered.
    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        // Disable controls while level is completed and game is over.
        if (GameManager.LevelIsCompleted || GameManager.GameIsOver)
            return;
        
        if (_gameIsPaused)
            Resume();
        else
            Pause();
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
        // Start the game normally and not paused.
        Time.timeScale = 1f;
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