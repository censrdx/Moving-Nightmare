using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Quit()  // Refrence to quit.
    {
        Debug.Log("QUIT");  // Debug in order to know if the script works.
        Application.Quit(); // Quit the application
    }

    // This is a public refrence to the PauseMenuUI component called "PauseMenu.LoadMenu".
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");     // Get menu scene and load it from build index.
    }
}