using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Public reference for the Quit function.
    private void Quit()
    {
        Debug.Log("QUIT");  // Debug in order to know if the script works.
        Application.Quit(); // Quit application
    }

    // Public reference to the PauseMenuUI component.
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");     // Get menu scene and load it from build index.
    }
}