using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Public reference to levelButtons array.
    public Button[] levelButtons;

    // Start is called before the first frame update.
    private void Start()
    {
        // Retrieve the current level reached, defaulting to 1 if it doesn't exist.
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); 

        // Loop through all existing buttons and set interactability based on player's progress.
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Levels up to levelReached are enabled; higher levels are locked.
            levelButtons[i].interactable = (i + 1 <= levelReached);
        }
    }

    // Public reference to the LevelSelector component.
    public void Select(string levelName)
    {
        // Load the scene that will be set to the inspector.
        SceneManager.LoadScene(levelName);
    }

    // Public reference to the LevelSelector component called "LevelSelector.LoadMenu".
    public void LoadMenu()
    {
        // Get menu scene from build index and load it.
        SceneManager.LoadScene("Menu");
    }
}
