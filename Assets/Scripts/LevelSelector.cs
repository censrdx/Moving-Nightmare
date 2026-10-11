using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Public refrence to levelButtons array.
    public Button[] levelButtons;

    // Start is called before the first frame update.
    void Start()
    {
        // Set active level 01 in PlayerPrefs.
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); 

        // Loop through all of the existing buttons and create a variable with the index of that button.
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Disable interactability.
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    // This is a public refrence to the LevelSelector component called "GameManager.Select(string levelName)".
    public void Select(string levelName)
    {
        // Load the scene that will be set to the inspector.
        SceneManager.LoadScene(levelName);
    }

    // This is a public refrence to the LevelSelector component called "LevelSelector.LoadMenu".
    public void LoadMenu()
    {
        // Get menu scene from build index and load it.
        SceneManager.LoadScene("Menu");
    }
}
