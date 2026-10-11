using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance so other scripts can access it easily via GameManager.Instance
    public static GameManager Instance { get; set; }

    // Mark gameHasEnded to false.
    public static bool GameIsOver { get; private set; }

    // Mark LevelIsCompleted to false.
    public static bool LevelIsCompleted { get; private set; }

    // Adjustable "restartDelay" in the inspector
    [SerializeField] private float restartDelay = 1f;

    // Public reference to the GameObject Component called completeLevelUI.
    [SerializeField] private GameObject completeLevelUI;

    // Public reference to the GameObject Component call gameOverUI.
    [SerializeField] private GameObject gameOverUI;

    // initialize variables or states before the application starts || https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.Awake.html
    private void Awake()
    {
        // Set up the Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Marked GameIsOver as false so it does not start the game as over.
        GameIsOver = false;
        // Marked LevelIsCompleted as false so it does not start the game as completed.
        LevelIsCompleted = false;
    }

    // Level complete function
    public void CompleteLevel()
    {
        if (LevelIsCompleted) return;
        Cursor.visible = true; // Make the cursor visible.
        Cursor.lockState = CursorLockMode.None; // Unlock cursor.
        LevelIsCompleted = true; // Set game state to level completed.
        Debug.Log("Level Completed"); // Display Level Completed message to the console.
        completeLevelUI.SetActive(true); // Set complete level UI to active
    }

    // Game over function
    // ReSharper disable Unity.PerformanceAnalysis
    public void EndGame()
    {
        if (!GameIsOver)
        {
            Cursor.visible = true; //Make cursor visible.
            Cursor.lockState = CursorLockMode.None; // Unlock cursor.
            GameIsOver = true; // Switch to game over state.
            Debug.Log("GAME OVER"); // Display GAME OVER message to the console.
            Invoke(nameof(Restart), restartDelay); // Call restart delay.
            gameOverUI.SetActive(true); // Enable game over UI.
        }
    }

    // Restart last level played function.
    public void Restart()
    {
        // Load last level played.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Main menu function.
    public void LoadMenu()
    {
        // Get menu scene from build index and load it.
        SceneManager.LoadScene("Menu");
    }
}