using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void StartGame()
    {
        // Load the scene that's in the queue in build settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
