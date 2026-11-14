using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Public reference for the Quit function.
    private void Quit()
    {
        // Debug in order to know if the script works.
        Debug.Log("QUIT");
        // Quit application
        Application.Quit();
    }

    // Public reference to the PauseMenuUI component.
    public void LoadMenu()
    {
        // Get menu scene and load it from build index.
        SceneManager.LoadScene("Menu");
    }
}