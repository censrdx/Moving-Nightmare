using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Find object from game manager and restart the level.
    public void Retry()
    {
        GameManager.Instance.Restart();
    }
    
    // Find object from game manager and load the menu.
    public void LoadMenu()
    {
        GameManager.Instance.LoadMenu();
    }
}
